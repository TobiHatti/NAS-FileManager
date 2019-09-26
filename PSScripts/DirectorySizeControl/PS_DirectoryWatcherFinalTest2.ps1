$abs="zivi@ooe.lebenshilfe.org"
$empf="support@ooe.lebenshilfe.org"
$sub="Speicher-Info H:\Laufwerk"
$smtp="exchange.ooe.lebenshilfe.org"

# Source Directory
# Executing client must have permission to see all directories!
$sourceRootFolder = "H:\"
$maxFileSize = 10GB



[System.Collections.ArrayList]$alertFolderNameList = @()
[System.Collections.ArrayList]$alertFolderSizeList = @()

function DirectoryCheck($path)
{
    [int]$fileSize = 0
    
    foreach($dir in Get-ChildItem -Path $path -Directory | Select-Object FullName)
    {
        $dir = "$dir".Replace("@{FullName=","").Replace("}","")

        # Get the size of files in a folder
        try
        {
            $fileSize = (Get-ChildItem $dir -File | Measure-Object -Property Length -Sum -ErrorAction Stop).Sum 
        }
        catch
        {
            $fileSize = 0
        }  
        
        if($fileSize -ge $maxFileSize)
        {
            echo "Folder over $(($maxFileSize/1GB).ToString("0.00"))GB detected: $dir"

            $alertFolderNameList.Add($dir)
            $alertFolderSizeList.Add($fileSize)
        }

        DirectoryCheck($dir) 
    }
}

DirectoryCheck($sourceRootFolder);


if($alertFolderNameList.Count -gt 0)
{
    $nachricht = '
        <!DOCTYPE html>
        <html>
	        <head>
	        </head>
	        <body>
		        <center>
				        <p>
					        <img style="display: block; margin-left: auto; margin-right: auto;" src="http://www.ooe.lebenshilfe.org/lebenshilfe/files/Lebenshilfe%20OOE/Bilder/Stellenangebote/Facette%2BLogo_oben.jpg" alt="http://www.ooe.lebenshilfe.org/lebenshilfe/files/Lebenshilfe%20OOE/Bilder/Stellenangebote/Facette%2BLogo_oben.jpg" />
				        </p>
			        </center>
			        <br />
			        <br />
			        <p style="text-align: center;">
				        <span style="font-size: 17pt; font-family: arial, helvetica, sans-serif;">
					        <strong>
						        <span style="line-height: 107%;">Ihr Speicherplatz ist ausgelastet!</span>
					        </strong>
				        </span>
			        </p>
			        <br /><br /><br />
			        <p>
			        <center>
				        <table style=" width: 650px; border: 1px solid; border-collapse: collapse; font-size: 13pt; font-family: arial, helvetica, sans-serif;">
					        <tbody>'

                            for($i = 0; $i -lt $alertFolderNameList.Count; $i++)
                            {
                                $nachricht += '
                                    <tr>
			                            <td style="width: 80%; border: 1px solid; padding-left: 5px;">
				                            ' + $alertFolderNameList[$i] + '
			                            </td>
			                            <td style="width: 20%; border: 1px solid; padding-right: 5px; text-align: right;">
				                            <strong> ' + ($alertFolderSizeList[$i]/1GB).ToString("0.00") + ' GB</strong>
			                            </td>
		                            </tr>
                                '
                            }

                            $nachricht += '

					        </tbody>
				        </table>
			        </p>
			        <br /><br /><br />
			        <p>
				        <img style="display: block; margin-left: auto; margin-right: auto;" src="http://www.ooe.lebenshilfe.org/logo/MailFooter.jpg" alt="http://www.ooe.lebenshilfe.org/logo/MailFooter.jpg" />
			        </p>
		        </center>
	        </body>
        </html>'

    Send-MailMessage -From $abs -to $empf -Subject $sub -Body $nachricht -SmtpServer $smtp -BodyAsHtml
}


