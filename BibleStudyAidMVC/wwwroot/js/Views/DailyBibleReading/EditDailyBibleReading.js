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

    AddReferenceEditModal();

    let addReferenceModal = new bootstrap.Modal(document.getElementById('referenceNewModal'), {
        backdrop: true,
        keyboard: false,
        focus: true
    });

    AddReferenceNewModal();

    let deleteReferenceModal = new bootstrap.Modal(document.getElementById('referenceDeleteModal'), {
        backdrop: true,
        keyboard: false,
        focus: true
    });

    AddReferenceDeleteModal();

});


//function to add eventlistener to edit reference modal
function AddReferenceEditModal() {
    const refTable = document.getElementById("referenceTableEdits");
    
    for (let i = 0; i < refTable.rows.length; i++) {
        const dataParentElement = refTable.rows[i];
        let editItemElement = refTable.rows[i].getElementsByTagName("td")[2].getElementsByTagName("i")[0];

        //Populate form
        editItemElement.addEventListener("click", () => {
            //Get current row Id
            const currentRowId = editItemElement.getAttribute("data-id");
            document.getElementById("referenceId").setAttribute("value", currentRowId);
            //Get FK ID
            let referenceForeignKeyId = editItemElement.getAttribute("reference-FK");
            document.getElementById("referenceFKId").setAttribute("value", referenceForeignKeyId);
            //Get current row Reference
            const currentRowReference = dataParentElement.children[0].innerHTML;
            document.getElementById("referenceCitation").setAttribute("value", currentRowReference);
            //Get current row Reference Description
            const currentRowReferenceDescription = dataParentElement.children[1].innerHTML;
            document.getElementById("referenceDescription").innerHTML = currentRowReferenceDescription;
            //show reference Modal
            referenceModal.show();
        });
    };
}

//function to add eventlistener to add new reference modal
function AddReferenceNewModal() {
    const refTable = document.getElementById("referenceTableEdits");

    for (let i = 0; i < refTable.rows.length; i++) {
        let newItemElement = refTable.rows[i].getElementsByTagName("td")[2].getElementsByTagName("i")[1];

        //Populate form
        newItemElement.addEventListener("click", () => {
            //Get FK ID
            let referenceForeignKeyId = newItemElement.getAttribute("reference-FK");
            document.getElementById("referenceNewFKId").setAttribute("value", referenceForeignKeyId);
            //show reference Modal
            referenceModal.show();
        });
    };
}

//function to add eventlistener to delete reference modal
function AddReferenceDeleteModal() {
    const refTable = document.getElementById("referenceTableEdits");

    for (let i = 0; i < refTable.rows.length; i++) {
        const dataParentElement = refTable.rows[i];
        let deleteItemElement = refTable.rows[i].getElementsByTagName("td")[2].getElementsByTagName("i")[2];

        //Populate form
        deleteItemElement.addEventListener("click", () => {
            //Get current row Id
            let currentRowDeletedId = deleteItemElement.getAttribute("data-id");
            document.getElementById("referenceDeleteId").setAttribute("value", currentRowDeletedId);
            //Get current row Reference
            const currentRowReference = dataParentElement.children[0].innerHTML;
            document.getElementById("referenceCitationDelete").innerHTML=currentRowReference;
            //Get current row Reference Description
            const currentRowReferenceDescription = dataParentElement.children[1].innerHTML;
            document.getElementById("referenceDescriptionDelete").innerHTML = currentRowReferenceDescription;
            //show reference Modal
            referenceModal.show();
        });
    };
}



