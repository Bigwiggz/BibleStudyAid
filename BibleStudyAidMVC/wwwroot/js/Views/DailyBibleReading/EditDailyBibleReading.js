/*
 * Edit Daily Bible Reading
 */

//Events
window.addEventListener("load", function () {
    let referenceModal = new bootstrap.Modal(document.getElementById('referenceModal'), {
        backdrop: true,
        keyboard: false,
        focus:true
    });


});


//function to add eventlistener to reference modal
function AddReferenceEditModal() {
    const refTable = document.getElementsByClassName("referenceTableEdits");
    for (let i = 0; i <= refTable.length; i++) {
        refTable[i].addEventListener("click", () => {
            //Get current row Id
            const currentRowId = refTable.getAttribute("data-id");
            document.getElementById("referenceId").setAttribute("value", currentRowId);
            //Get current row Reference
            const currentRowReference = refTable.closest("tr")[0].innerHTML;
            document.getElementById("referenceCitation").setAttribute("value", currentRowReference);
            //Get current row Reference Description
            const currentRowReferenceDescription = refTable.closest("tr")[1].innerHTML;
            document.getElementById("referenceDescription").setAttribute("value", currentRowReferenceDescription);
            //show reference Modal
            referenceModal.show();
        });
    };
}

