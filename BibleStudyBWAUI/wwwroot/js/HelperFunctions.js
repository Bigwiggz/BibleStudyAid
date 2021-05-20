/*
 * This is a list of javascript helper functions for the app
 */

//function to convert blob to array buffers
function base64ToArrayBuffer(base64) {
    var binaryString = window.atob(base64);
    var binaryLen = binaryString.length;
    var bytes = new Uint8Array(binaryLen);
    for (var i = 0; i < binaryLen; i++) {
        var ascii = binaryString.charCodeAt(i);
        bytes[i] = ascii;
    }
    return bytes;
}

//function to save file
function saveByteArray(reportName, byte, filetype) {
    var blob = new Blob([byte], { type: filetype });
    var link = document.createElement('a');
    link.href = window.URL.createObjectURL(blob);
    var fileName = reportName;
    link.download = fileName;
    link.click();
};

//Call function from C# blazor code
function downloadSelectedFile(document) {
    let data = document.Document;
    let fileName = document.DocumentName;
    let fileType = document.DocumentType;
    var sampleArr = base64ToArrayBuffer(data);
    saveByteArray(fileName, sampleArr, fileType);
}

