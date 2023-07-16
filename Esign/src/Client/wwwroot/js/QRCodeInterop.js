window.generateQRCode = (url) => {
    const typeNumber = 4; // QR code type, adjust as needed
    const errorCorrectionLevel = 'L'; // Error correction level, adjust as needed
    const qr = qrcode(typeNumber, errorCorrectionLevel);
    qr.addData(url);
    qr.make();

    const qrCodeImageElement = document.getElementById('qrCodeImage');
    qrCodeImageElement.src = qr.createDataURL();
};
