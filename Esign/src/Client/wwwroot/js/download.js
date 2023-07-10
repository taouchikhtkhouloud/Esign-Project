// interop.js
window.BlazorDownloadFile = (fileName, content) => {
    const blob = new Blob([content]);
    const link = document.createElement('a');
    link.href = window.URL.createObjectURL(blob);
    link.download = fileName;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
};
