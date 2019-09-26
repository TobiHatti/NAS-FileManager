Import-Module PSSQLite
Get-Command -Module PSSQLite

$targetDirectory = "D:\ClientShareClones"


$database = "C:\Users\Administrator.HTSTORAGE\Desktop\hashInfo.db"

$dataTable = New-Object System.Data.DataTable 'hashfiles'
$newCol = New-Object System.Data.DataColumn Filename,([string]); $dataTable.Columns.Add($newCol)
$newCol = New-Object System.Data.DataColumn Hash,([string]); $dataTable.Columns.Add($newCol)

Write-Host -ForegroundColor Yellow "Starting..."

$i = 0
foreach($file in Get-ChildItem $targetDirectory -Recurse -Force -File)
{   
    if($i -ge 10000)
    {
        $i = 0
        Write-Host -ForegroundColor Yellow "Pasting to DB..."
        Invoke-SQLiteBulkCopy -DataTable $dataTable -DataSource $database -Table files -NotifyAfter 1000 -Verbose -Confirm:$false
        $dataTable.Clear()
    }
    $i++

    Write-Host -ForegroundColor Yellow "Cycle $i..."

    $hash = Get-FileHash $file.FullName -Algorithm SHA256


    $row = ($file.FullName, $hash.Hash)
    $dataTable.Rows.Add($row)
    

}

Write-Host -ForegroundColor Yellow "Pasting to DB..."
Invoke-SQLiteBulkCopy -DataTable $dataTable -DataSource $database -Table files -NotifyAfter 10 -Verbose -Confirm:$false
