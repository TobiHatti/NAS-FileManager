Import-Module PSSQLite
Get-Command -Module PSSQLite

$targetDirectory = "D:\ClientShareClones"


$database = "C:\Users\Administrator.HTSTORAGE\Desktop\hashInfo.db"

Write-Host -ForegroundColor Yellow "Starting..."

foreach($file in Get-ChildItem $targetDirectory -Recurse -Force -File)
{
    $hash = Get-FileHash $file.FullName -Algorithm SHA256

    Write-Host "$($hash.Hash) - $($file.FullName)"

    $query = "INSERT INTO files (Filename, Hash) VALUES (@Filename, @Hash)"
    Invoke-SqliteQuery -Database $database -Query $query -SqlParameters @{
        Filename = $file.FullName
        Hash = $hash.Hash
    }
}

pause