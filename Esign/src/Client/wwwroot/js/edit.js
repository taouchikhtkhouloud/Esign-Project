async function editDocument(documentUrl) {
    const { PDFDocument, StandardFonts, rgb } = PDFLib;
    const pdfDoc = await PDFDocument.create();
    const page = pdfDoc.addPage();
    const { width, height } = page.getSize();
    const fontSize = 30;
    page.drawText('Creating PDFs in JavaScript is awesome!', {
        x: 50,
        y: height - 4 * fontSize,
        size: fontSize,
        color: rgb(0, 0.53, 0.71),
    });
    const jpgUrl = 'https://pdf-lib.js.org/assets/cat_riding_unicorn.jpg';
    const pngUrl = 'https://pdf-lib.js.org/assets/minions_banana_alpha.png';

    const jpgImageBytes = await fetch(jpgUrl).then((res) => res.arrayBuffer());
    const pngImageBytes = await fetch(pngUrl).then((res) => res.arrayBuffer());


    const jpgImage = await pdfDoc.embedJpg(jpgImageBytes);
    const pngImage = await pdfDoc.embedPng(pngImageBytes);

    const jpgDims = jpgImage.scale(0.5);
    const pngDims = pngImage.scale(0.5);


    page.drawImage(jpgImage, {
        x: page.getWidth() / 2 - jpgDims.width / 2,
        y: page.getHeight() / 2 - jpgDims.height / 2 + 250,
        width: jpgDims.width,
        height: jpgDims.height,
    });
    page.drawImage(pngImage, {
        x: page.getWidth() / 2 - pngDims.width / 2 + 75,
        y: page.getHeight() / 2 - pngDims.height + 250,
        width: pngDims.width,
        height: pngDims.height,
    });

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
