namespace university_management_service.srcs.Utils;

public static class CertificateTemplates
{
    public static string GetDefaultTemplate()
    {
        return @"
<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Certificate of Achievement</title>
    <style>
        body {
            font-family: 'Georgia', serif;
            margin: 0;
            padding: 40px;
            background-color: #f5f5f5;
        }
        .certificate {
            max-width: 800px;
            margin: 0 auto;
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            padding: 40px;
            border-radius: 15px;
            box-shadow: 0 10px 30px rgba(0,0,0,0.3);
        }
        .certificate-content {
            background: white;
            padding: 60px;
            border-radius: 10px;
            border: 3px solid #d4af37;
            position: relative;
        }
        .certificate-header {
            text-align: center;
            margin-bottom: 40px;
        }
        .certificate-title {
            font-size: 48px;
            color: #2c3e50;
            margin: 0;
            font-weight: bold;
            text-transform: uppercase;
            letter-spacing: 3px;
        }
        .certificate-subtitle {
            font-size: 20px;
            color: #7f8c8d;
            margin-top: 10px;
        }
        .certificate-body {
            text-align: center;
            margin: 40px 0;
        }
        .certificate-text {
            font-size: 18px;
            color: #34495e;
            line-height: 1.8;
            margin: 20px 0;
        }
        .student-name {
            font-size: 36px;
            color: #667eea;
            font-weight: bold;
            margin: 30px 0;
            text-decoration: underline;
            text-decoration-color: #d4af37;
        }
        .certificate-description {
            font-size: 16px;
            color: #555;
            margin: 20px 0;
            font-style: italic;
        }
        .certificate-footer {
            display: flex;
            justify-content: space-between;
            margin-top: 60px;
            padding-top: 30px;
            border-top: 2px solid #ecf0f1;
        }
        .signature-block {
            text-align: center;
        }
        .signature-line {
            width: 200px;
            border-top: 2px solid #2c3e50;
            margin: 10px auto;
        }
        .signature-label {
            font-size: 14px;
            color: #7f8c8d;
            margin-top: 5px;
        }
        .date {
            font-size: 14px;
            color: #7f8c8d;
            text-align: center;
            margin-top: 20px;
        }
        .seal {
            position: absolute;
            bottom: 20px;
            right: 20px;
            width: 80px;
            height: 80px;
            border: 3px solid #d4af37;
            border-radius: 50%;
            display: flex;
            align-items: center;
            justify-content: center;
            background: #fff;
            font-size: 12px;
            color: #d4af37;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <div class='certificate'>
        <div class='certificate-content'>
            <div class='certificate-header'>
                <h1 class='certificate-title'>Certificate</h1>
                <p class='certificate-subtitle'>of Achievement</p>
            </div>
            
            <div class='certificate-body'>
                <p class='certificate-text'>This is to certify that</p>
                <div class='student-name'>{{STUDENT_NAME}}</div>
                <p class='certificate-text'>has successfully completed</p>
                <p class='certificate-description'>{{CERTIFICATE_DESCRIPTION}}</p>
                <p class='certificate-text'>and is hereby awarded this certificate in recognition of their dedication and achievement.</p>
            </div>
            
            <div class='certificate-footer'>
                <div class='signature-block'>
                    <div class='signature-line'></div>
                    <p class='signature-label'>Director's Signature</p>
                </div>
                <div class='signature-block'>
                    <div class='signature-line'></div>
                    <p class='signature-label'>Dean's Signature</p>
                </div>
            </div>
            
            <p class='date'>Issued on: {{ISSUE_DATE}}</p>
            
            <div class='seal'>
                OFFICIAL<br>SEAL
            </div>
        </div>
    </div>
</body>
</html>";
    }
    
    public static string GetHonorsCertificateTemplate()
    {
        return @"
<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Certificate of Honors</title>
    <style>
        body {
            font-family: 'Times New Roman', serif;
            margin: 0;
            padding: 40px;
            background-color: #1a1a1a;
        }
        .certificate {
            max-width: 900px;
            margin: 0 auto;
            background: linear-gradient(135deg, #c9a227 0%, #f4e5a1 50%, #c9a227 100%);
            padding: 50px;
            border-radius: 20px;
            box-shadow: 0 15px 40px rgba(0,0,0,0.5);
        }
        .certificate-content {
            background: white;
            padding: 80px;
            border-radius: 15px;
            border: 5px double #c9a227;
            position: relative;
        }
        .certificate-header {
            text-align: center;
            margin-bottom: 50px;
            border-bottom: 3px solid #c9a227;
            padding-bottom: 20px;
        }
        .certificate-title {
            font-size: 56px;
            color: #c9a227;
            margin: 0;
            font-weight: bold;
            text-transform: uppercase;
            letter-spacing: 5px;
            text-shadow: 2px 2px 4px rgba(0,0,0,0.1);
        }
        .certificate-subtitle {
            font-size: 24px;
            color: #333;
            margin-top: 15px;
            font-style: italic;
        }
        .certificate-body {
            text-align: center;
            margin: 50px 0;
        }
        .certificate-text {
            font-size: 20px;
            color: #2c3e50;
            line-height: 2;
            margin: 25px 0;
        }
        .student-name {
            font-size: 42px;
            color: #c9a227;
            font-weight: bold;
            margin: 40px 0;
            text-decoration: underline;
            text-decoration-color: #c9a227;
            text-transform: uppercase;
        }
        .certificate-description {
            font-size: 18px;
            color: #555;
            margin: 30px 0;
            font-style: italic;
            font-weight: bold;
        }
        .honors-badge {
            display: inline-block;
            background: #c9a227;
            color: white;
            padding: 10px 30px;
            border-radius: 50px;
            font-size: 16px;
            font-weight: bold;
            margin: 20px 0;
            text-transform: uppercase;
        }
        .certificate-footer {
            display: flex;
            justify-content: space-around;
            margin-top: 80px;
            padding-top: 40px;
            border-top: 3px solid #c9a227;
        }
        .signature-block {
            text-align: center;
        }
        .signature-line {
            width: 250px;
            border-top: 3px solid #c9a227;
            margin: 15px auto;
        }
        .signature-label {
            font-size: 16px;
            color: #333;
            margin-top: 10px;
            font-weight: bold;
        }
        .date {
            font-size: 16px;
            color: #666;
            text-align: center;
            margin-top: 30px;
            font-style: italic;
        }
        .seal {
            position: absolute;
            bottom: 30px;
            right: 30px;
            width: 100px;
            height: 100px;
            border: 5px solid #c9a227;
            border-radius: 50%;
            display: flex;
            align-items: center;
            justify-content: center;
            background: white;
            font-size: 14px;
            color: #c9a227;
            font-weight: bold;
            box-shadow: 0 5px 15px rgba(0,0,0,0.2);
        }
    </style>
</head>
<body>
    <div class='certificate'>
        <div class='certificate-content'>
            <div class='certificate-header'>
                <h1 class='certificate-title'>Certificate</h1>
                <p class='certificate-subtitle'>of Honors & Excellence</p>
            </div>
            
            <div class='certificate-body'>
                <p class='certificate-text'>This prestigious certificate is awarded to</p>
                <div class='student-name'>{{STUDENT_NAME}}</div>
                <div class='honors-badge'>With Honors</div>
                <p class='certificate-text'>for outstanding achievement in</p>
                <p class='certificate-description'>{{CERTIFICATE_DESCRIPTION}}</p>
                <p class='certificate-text'>demonstrating exceptional dedication, excellence, and commitment to academic pursuits.</p>
            </div>
            
            <div class='certificate-footer'>
                <div class='signature-block'>
                    <div class='signature-line'></div>
                    <p class='signature-label'>University Director</p>
                </div>
                <div class='signature-block'>
                    <div class='signature-line'></div>
                    <p class='signature-label'>Dean of Faculty</p>
                </div>
                <div class='signature-block'>
                    <div class='signature-line'></div>
                    <p class='signature-label'>Head of Department</p>
                </div>
            </div>
            
            <p class='date'>Issued on: {{ISSUE_DATE}}</p>
            
            <div class='seal'>
                HONORS<br>SEAL
            </div>
        </div>
    </div>
</body>
</html>";
    }
    
    public static string GetTemplate(string templateName)
    {
        return templateName.ToLower() switch
        {
            "honors" => GetHonorsCertificateTemplate(),
            "default" => GetDefaultTemplate(),
            _ => GetDefaultTemplate()
        };
    }
}
