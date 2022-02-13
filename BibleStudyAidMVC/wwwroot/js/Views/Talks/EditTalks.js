/*
 * Edit Talks
 */

/////////////////////////
//Modals
/////////////////////////

//Events
window.addEventListener("load", function () {

    //Reference Modals
    let referenceModal = new bootstrap.Modal(document.getElementById('referenceModal'), {
        backdrop: true,
        keyboard: false,
        focus: true
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

    //Scripture Modals
    let addScriptureModal = new bootstrap.Modal(document.getElementById('scriptureNewModal'), {
        backdrop: true,
        keyboard: false,
        focus: true
    });

    AddScriptureNewModal();

    let scriptureDeleteModal = new bootstrap.Modal(document.getElementById('scriptureDeleteModal'), {
        backdrop: true,
        keyboard: false,
        focus: true
    });

    AddScriptureDeleteModal();

});

/*REFERENCE MODAL*/

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
            document.getElementById("referenceCitationDelete").innerHTML = currentRowReference;
            //Get current row Reference Description
            const currentRowReferenceDescription = dataParentElement.children[1].innerHTML;
            document.getElementById("referenceDescriptionDelete").innerHTML = currentRowReferenceDescription;
            //show reference Modal
            referenceModal.show();
        });
    };
}

/*SCRIPTURE MODALS*/

//functionto add eventlistener to new scripture modal
function AddScriptureNewModal() {
    const scripturalTable = document.getElementById("scripturalTableEdits");
    for (let i = 0; i < scripturalTable.rows.length; i++) {
        let newItemElement = scripturalTable.rows[i].getElementsByTagName("td")[2].getElementsByTagName("i")[1];
        newItemElement.addEventListener("click", () => {
            //show reference modal
            referenceModal.show();

        });
    }
}

//function to add eventlistener to delete reference modal
function AddScriptureDeleteModal() {
    const scripturalTable = document.getElementById("scripturalTableEdits");

    for (let i = 0; i < scripturalTable.rows.length; i++) {
        const dataParentElement = scripturalTable.rows[i];
        let deleteItemElement = scripturalTable.rows[i].getElementsByTagName("td")[2].getElementsByTagName("i")[2];

        //Populate form
        deleteItemElement.addEventListener("click", () => {
            //Get current row Id
            let currentRowDeletedId = deleteItemElement.getAttribute("data-id");
            document.getElementById("scriptureDeleteId").setAttribute("value", currentRowDeletedId);
            //Get current row Scripture
            const currentRowScripture = dataParentElement.children[0].innerHTML;
            document.getElementById("scriptureDelete").innerHTML = currentRowScripture;
            //Get current row Reference Description
            const currentRowScriptureDescription = dataParentElement.children[1].innerHTML;
            document.getElementById("scriptureDescriptionDelete").innerHTML = currentRowScriptureDescription;
            //show reference Modal
            referenceModal.show();
        });
    };
}


/////////////////////////
//Document Table Select
/////////////////////////

/*
Table Select
*/


//Global Variables


let tableIdArray = [];


//Events


//On Page Load event
window.onload = (event) => {
    WireUpTableSelectOnEachRow("table-primary", "tableDocumentBody");
};

//On button Submit
document.getElementById("submitDownloadButton").addEventListener("click", () => {
    SubmitTableIdArray("table-primary", "tableDocumentBody");
});



//Functions


//function to add onclick to each table row
function WireUpTableSelectOnEachRow(tableSelectClass, tableBody) {
    let table = document.getElementById(tableBody);
    for (let i = 0; i < table.rows.length; i++) {
        let currentTableRow = table.rows[i];

        //Add on click event
        currentTableRow.addEventListener("click", () => {
            //Add/Remove select css class to row
            ToggleSelectedRowCSS(currentTableRow, tableSelectClass);
            //Add/Remove id from array of ids
            ToggleSelectedRowId(currentTableRow);
        });

    }
}

//function to toggle selector css
function ToggleSelectedRowCSS(currentTableRow, className) {
    if (currentTableRow.classList.contains(className)) {
        currentTableRow.classList.remove(className);
    }
    else {
        currentTableRow.classList.add(className);
    };
}

//function to toggle selected Id from array
function ToggleSelectedRowId(currentTableRow) {
    let rowId = parseInt(currentTableRow.getAttribute("doc-id"));
    if (tableIdArray.includes(rowId)) {
        tableIdArray = tableIdArray.filter(e => e !== rowId);
    }
    else {
        tableIdArray.push(rowId);
    };
}

//function to send array to controller on button click
function SubmitTableIdArray(className, tableBody) {
    //TODO: Send tableIdArray to post controller through fetch
    document.getElementById("DownloadSubmit").setAttribute("value", JSON.stringify(tableIdArray));
    console.log(JSON.stringify(tableIdArray));
    ResetSelection(className, tableBody);
}

//function to reset selection
function ResetSelection(className, tableBody) {
    //remove selection off all elements
    let tableRows = Array.from(document.getElementById(tableBody).rows);
    tableRows.forEach(e => e.classList.remove(className));

    //empty array
    tableIdArray = [];
}

/////////////////////////
//Tags
/////////////////////////

//Variables
let allTagList = [];
let existingTagList = [];
let selectedTagsToAdd = [];

//on load
window.addEventListener('load', () => {
    //Get tags list
    GetCurrentTagsList();
});

//on click add tag(s)
document.getElementById("AllTagList").addEventListener("change", () => {
    let select = document.getElementById("AllTagList");
    selectedTagsToAdd = GetSelectTagValues(select);
    console.log(JSON.stringify(selectedTagsToAdd));
    document.getElementById("addTagsId").setAttribute("value", JSON.stringify(selectedTagsToAdd));

    //TODO: Update DOM
});

//on click remove tag(s)
document.getElementById("ExistingTagList").addEventListener("change", () => {
    let select = document.getElementById("ExistingTagList");
    selectTagsToRemove = GetSelectTagValues(select);
    console.log(selectTagsToRemove);
    document.getElementById("removeTagsId").setAttribute("value", JSON.stringify(selectTagsToRemove));

    //TODO: Update DOM
});




//Functions
//Get list data
function GetCurrentTagsList() {
    //Get current tags list
    existingTagList = getTalksData.tags;
    PopulateTagsList(existingTagList, "ExistingTagList");


    //Get all tags list
    postData('/TagsData')
        .then(data => {
            allTagList = data;
            PopulateTagsList(allTagList, "AllTagList");
            console.log(allTagsList);
        });

}



//Populate array
function PopulateTagsList(tagsList, selectListId) {
    let select = document.getElementById(selectListId);
    let options = tagsList.map(tag => `<option value=${tag.id}>${tag.tagName}</option>`).join('\n');
    select.innerHTML = options;
}

//TODO: FIX THIS
//get selected results
function GetSelectTagValues(select) {
    let result = [];
    let options = select && select.options;
    let opt;

    for (let i = 0, iLen = options.length; i < iLen; i++) {
        opt = options[i];

        if (opt.selected) {
            result.push(parseInt(opt.value));
        }
    }
    return result;
}

//FETCH FUNCTION

// Example POST method implementation:
async function postData(url = '', data = {}) {
    // Default options are marked with *
    const response = await fetch(url, {
        method: 'POST', // *GET, POST, PUT, DELETE, etc.
        mode: 'cors', // no-cors, *cors, same-origin
        cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
        credentials: 'same-origin', // include, *same-origin, omit
        headers: {
            'Content-Type': 'application/json'
            // 'Content-Type': 'application/x-www-form-urlencoded',
        },
        redirect: 'follow', // manual, *follow, error
        referrerPolicy: 'no-referrer', // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
        body: JSON.stringify(data) // body data type must match "Content-Type" header
    });
    return response.json(); // parses JSON response into native JavaScript objects
}

