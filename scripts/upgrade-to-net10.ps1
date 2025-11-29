param(
    [string]$RepoRoot = (Get-Location).Path,
    [switch]$WhatIf
)

Set-StrictMode -Version Latest
Write-Host "Repository root: $RepoRoot"

Push-Location $RepoRoot

# Create feature branch
if (-not $WhatIf) {
    git fetch origin
    git switch -c upgrade/net10 -ErrorAction SilentlyContinue | Out-Null
    if ($LASTEXITCODE -ne 0) { git checkout -b upgrade/net10 } 
} else {
    Write-Host "[WhatIf] Would create branch upgrade/net10"
}

# Helper to update file contents
function Update-File {
    param(
        [string]$Path,
        [string]$NewContent
    )
    if ($WhatIf) {
        Write-Host "[WhatIf] Would update: $Path"
    } else {
        $NewContent | Set-Content -LiteralPath $Path -Encoding UTF8
        Write-Host "Updated: $Path"
    }
}

# 1) Replace TFMs in csproj/props
$projFiles = Get-ChildItem -Path $RepoRoot -Recurse -Include *.csproj,*.props -File -ErrorAction SilentlyContinue
foreach ($f in $projFiles) {
    $text = Get-Content -Raw -LiteralPath $f.FullName
    $new = $text -replace 'net8\.0','net10.0'
    if ($new -ne $text) { Update-File -Path $f.FullName -NewContent $new }
}

# 2) Update global.json if present
$globalJsonPath = Join-Path $RepoRoot 'global.json'
if (Test-Path $globalJsonPath) {
    try {
        $json = Get-Content -Raw -LiteralPath $globalJsonPath | ConvertFrom-Json
        if (-not $json.sdk) { $json | Add-Member -MemberType NoteProperty -Name sdk -Value @{} }
        $json.sdk.version = '10.0.100'
        $out = $json | ConvertTo-Json -Depth 10
        Update-File -Path $globalJsonPath -NewContent $out
    } catch {
        Write-Warning "Failed to parse global.json; skipping automated JSON update. (File left unchanged)"
    }
}

# 3) Update Dockerfiles
$dockerFiles = Get-ChildItem -Path $RepoRoot -Recurse -Include Dockerfile,*Dockerfile -File -ErrorAction SilentlyContinue
foreach ($f in $dockerFiles) {
    $text = Get-Content -Raw -LiteralPath $f.FullName
    $new = $text -replace 'mcr\.microsoft\.com/dotnet/aspnet:8(\.0)?','mcr.microsoft.com/dotnet/aspnet:10.0'
    $new = $new -replace 'mcr\.microsoft\.com/dotnet/sdk:8(\.0)?','mcr.microsoft.com/dotnet/sdk:10.0'
    if ($new -ne $text) { Update-File -Path $f.FullName -NewContent $new }
}

# 4) Update GitHub Actions workflows (dotnet-version)
$workflowFiles = Get-ChildItem -Path (Join-Path $RepoRoot '.github') -Recurse -Include *.yml,*.yaml -File -ErrorAction SilentlyContinue
foreach ($f in $workflowFiles) {
    $text = Get-Content -Raw -LiteralPath $f.FullName
    $new = $text -replace 'dotnet-version:\s*["'']?8(\.0)?["'']?','dotnet-version: 10.x'
    $new = $new -replace 'dotnet-version:\s*["'']?8\.x["'']?','dotnet-version: 10.x'
    if ($new -ne $text) { Update-File -Path $f.FullName -NewContent $new }
}

# 5) Stage and commit
if ($WhatIf) {
    Write-Host "[WhatIf] Would run: git add -A"
    Write-Host "[WhatIf] Would run: git commit -m 'chore(upgrade): migrate projects and CI/Docker to .NET 10'"
} else {
    git add -A
    git commit -m "chore(upgrade): migrate projects and CI/Docker to .NET 10" -q 2>$null
    if ($LASTEXITCODE -eq 0) {
        Write-Host "Committed changes on branch upgrade/net10"
    } else {
        Write-Host "No changes to commit or commit failed (check git status)."
    }
}

Pop-Location

Write-Host ""
Write-Host "Done. Next steps:"
Write-Host "  1) Install a .NET 10 SDK locally if not already installed."
Write-Host "  2) From the repo root run: __dotnet --version__, then __dotnet restore__, __dotnet build --configuration Release__, __dotnet test__"
Write-Host "  3) Fix any compile or API breaking changes reported by the build/tests and update NuGet packages as needed."