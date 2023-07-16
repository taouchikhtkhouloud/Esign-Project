async function editDocument(documentUrl) {
    const { PDFDocument, StandardFonts, rgb, SVG } = PDFLib;
    const url = '../Files/Documents/Northwind Report.pdf';
    //const filename = 'AWS Certified Cloud Practitioner.pdf';
    const filePath = encodeURI(documentUrl);
    const existingPdfBytes = await fetch(filePath).then(res => res.arrayBuffer())

    const pdfDoc = await PDFDocument.load(existingPdfBytes)
    const helveticaFont = await pdfDoc.embedFont(StandardFonts.Helvetica)
    const svgData = "../qr.png";
    const pngImageBytes = await fetch(svgData).then((res) => res.arrayBuffer());
    const svgImage = await pdfDoc.embedPng(pngImageBytes);

    //const image = await getQRCode("vv");
    const pngDims = svgImage.scale(0.5)
    const page = pdfDoc.addPage();
    const { width, height } = page.getSize();
    const fontSize = 30;
    page.drawText('document signed!', {
        x: 50,
        y: height - 4 * fontSize,
        size: fontSize,
        color: rgb(0, 0.53, 0.71),
    });
    page.drawImage(svgImage, {
        x: page.getWidth() / 2 - pngDims.width / 2 + 75,
        y: page.getHeight() / 2 - pngDims.height + 250,
        width: pngDims.width,
        height: pngDims.height,
    });
    
    //page.drawImage(pngImage1, {
    //    x: page.getWidth() / 2 - pngDims.width / 2 + 75,
    //    y: page.getHeight() / 2 - pngDims.height + 250,
    //    width: pngDims1.width,
    //    height: pngDims1.height,
    //});
    const pdfBytes = await pdfDoc.save();

    // Create a Blob from the PDF bytes
    const pdfBlob = new Blob([pdfBytes], { type: 'application/pdf' });

    // Generate a temporary download link
    const link = document.createElement('a');
    link.href = window.URL.createObjectURL(pdfBlob);
    link.download = 'generated_pdf.pdf';

    // Trigger the download
    link.click();
}

async function getQRCode(text) {
    const qrCode = new QRCodeStyling({
        width: 300,
        height: 300,
        type: "svg",
        data: "https://www.facebook.com/",
        image: "https://upload.wikimedia.org/wikipedia/commons/5/51/Facebook_f_logo_%282019%29.svg",
        dotsOptions: {
            color: "#4267b2",
            type: "rounded"
        },
        backgroundOptions: {
            color: "#e9ebee",
        },
        imageOptions: {
            crossOrigin: "anonymous",
            margin: 20
        }
    });

    // Generate the QR code as PNG image bytes
    //const t=qrCode.getRawData("png").then((buffer) => {
    //    fs.writeFileSync("test.png", buffer);
    //});
    ////const link = document.createElement('b');
    ////link.href = window.URL.createObjectURL(t);
    ////link.download = 'test.png';
    

    //// Return the image bytes
    //return t;
    qrCode.download({ name: "qr" });
}