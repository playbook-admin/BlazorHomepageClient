# Save this script as "Export-SolutionStructure.ps1"

param (
    [string]$solutionPath = ".\YourSolution.sln"
)

function Get-FolderStructure {
    param (
        [string]$path,
        [int]$indent = 0
    )

    $indentation = " " * $indent
    Get-ChildItem -Path $path | ForEach-Object {
        if ($_.PSIsContainer) {
            Write-Output "$indentation$($_.Name)/"
            Get-FolderStructure -path $_.FullName -indent ($indent + 2)
        } else {
            Write-Output "$indentation$($_.Name)"
        }
    }
}

$solutionDir = [System.IO.Path]::GetDirectoryName($solutionPath)
$structure = Get-FolderStructure -path $solutionDir
$structure | Out-File -FilePath "SolutionStructure.txt"
