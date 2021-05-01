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

//function to sae file
function saveByteArray(reportName, byte, filetype) {
    var blob = new Blob([byte], { type: filetype });
    var link = document.createElement('a');
    link.href = window.URL.createObjectURL(blob);
    var fileName = reportName;
    link.download = fileName;
    link.click();
};

/*
 * Example of use
var sampleArr = base64ToArrayBuffer(data);
var fileType="application/pdf";
saveByteArray("Sample Report", sampleArr,fileType);
 */