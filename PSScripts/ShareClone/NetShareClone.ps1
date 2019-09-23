$netShares = Get-Content -Path C:\Users\Administrator.HTSTORAGE\Desktop\netShareCloneSource.ini
$cloneConfig = Get-Content C:\Users\Administrator.HTSTORAGE\Desktop\netShareCloneConfig.ini | foreach-object -begin {$config=@{}} -process { $k = [regex]::split($_,'='); if(($k[0].CompareTo("") -ne 0) -and ($k[0].StartsWith("[") -ne $True)) { $config.Add($k[0], $k[1]) } }


foreach($share in $netShares)
{
    if(Test-Path $share)
    {
        Write-Host -ForegroundColor Green -BackgroundColor Black "[INFO]   : Successfully reached `"$share`"!"
        
        
        if($config.Get_Item("CloneEnabled") -eq $true)
        {
            Write-Host -ForegroundColor Green -BackgroundColor Black "[INFO]   : Starting clone of `"$share`"..."
            $sourceFolder = $share
            $destinationFolder = "$($config.Get_Item("DestinationFolder"))\$($share.Remove(0,2).Replace('\','.'))\$(Get-Date -UFormat %Y-%M-%D)"


            if($config.Get_Item("IncludeRecycleBin") -eq $false)
            {
                Write-Host -ForegroundColor Green -BackgroundColor Black "[INFO]   : Preparation..."

                $Exclude = Get-ChildItem -Path $sourceFolder -Recurse -Force |
                  Where-Object { $_.FullName -like '*System Volume Information*' -or
                                 $_.FullName -like '*$RECYCLE.BIN*'}

                 Write-Host -ForegroundColor Green -BackgroundColor Black "[INFO]   : Ready with preparation, starting clone of `"$share`"..."

                Copy-Item -Path $sourceFolder -Destination $destinationFolder -Recurse -Force -Exclude $Exclude.FullName -ErrorAction SilentlyContinue

                
            }
            else
            {
                Copy-Item -Path $sourceFolder -Destination $destinationFolder -Recurse -Force SilentlyContinue
            }

            Write-Host -ForegroundColor Green -BackgroundColor Black "[INFO]   : Cloning of `"$share`" complete!"
        }
        else
        {
            Write-Host -ForegroundColor Yellow -BackgroundColor Black "[WARNING]: Cloning is not enabled!"
        }

    }
    else
    {
        Write-Host -ForegroundColor Red -BackgroundColor Black "[ERROR]  : The Network-Share `"$share`" could not be reached! Check if the Computer is turned on and if the network-share is active!"
    }

   
}

