/*
This is the logic to selecting and editing scriptures
*/



//Global Variables
let SelectedBook="";
let SelectedChapter=null;
let ChapterList=[];
let SelectedVerse=null;
let VerseCount=null;

////////////////////////
//Events
///////////////////////
//On Page Load Events
window.addEventListener("load", () => {
	PopulateBookSelector("SelectBook");
	console.log("Loaded Bible Scripture Logic");
});

//On select Book Events
document.getElementById("SelectBook").addEventListener("change",()=>{
	ClearAllValuesBookLevel();
	PopulateChapterSelector("SelectChapter");
});

//On select Chapter Events
document.getElementById("SelectChapter").addEventListener("change",()=>{
	ClearAllValuesChapterLevel();
	PopulateVerseSelector("SelectVerse");
});

//On select Verse Events
document.getElementById("SelectVerse").addEventListener("change",()=>{
	ClearAllValuesVerseLevel();
	GetFinalScripture("SelectVerseGroup");
});

//On select Verse Group
document.getElementById("SelectVerseGroup").addEventListener("change",()=>{
	GetToVerseGroupSpan();
});

/////////////////////////
//FUNCTIONS
/////////////////////////

//This function adds the books to the selector list
function PopulateBookSelector(TopSelector){
	let BooksList=BibleScriptureDoc.map(b=>b.name);
	PopulateSelectList(BooksList,TopSelector);
}

//This function adds the chapters to the selector list
function PopulateChapterSelector(TopSelector){
	//Enable Chapter Selector
	document.getElementById("SelectChapter").removeAttribute("disabled");
	//Get selected book
	let selector=document.getElementById("SelectBook");
	SelectedBook=selector.options[selector.selectedIndex].text;
	ChapterCount=BibleScriptureDoc.filter(b=>b.name===SelectedBook)[0].chapters.length;
	ChapterList=[];
	if(ChapterCount>1){
		for(let i=1; i<=ChapterCount; i++){
			ChapterList.push(i);
		}
		PopulateSelectList(ChapterList,TopSelector);
	}
	else{
		PopulateVersesOfBooksWithNoChapters("SelectVerse");
	}
}

//This function adds the verses to the selector list
function PopulateVerseSelector(TopSelector){
	//Enable Verse Selector
	document.getElementById("SelectVerse").removeAttribute("disabled");
	//Get Selected Chapter
	let selector=document.getElementById("SelectChapter");
	SelectedChapterText=selector.options[selector.selectedIndex].text;
	SelectedChapter=parseInt(SelectedChapterText);
	VerseCount=BibleScriptureDoc.filter(b=>b.name===SelectedBook)[0].chapters[SelectedChapter];
	let VerseList=[];
	for(let i=1; i<=VerseCount; i++){
		VerseList.push(i);
	}
	PopulateSelectList(VerseList,TopSelector);
}

//This function adds verses ONLY to books with no chapters
function PopulateVersesOfBooksWithNoChapters(TopSelector){
	//Disable Chapter Selector
	document.getElementById("SelectChapter").setAttribute("disabled","disabled");
	//Enable Verse Selector
	document.getElementById("SelectVerse").removeAttribute("disabled");
	VerseCount=BibleScriptureDoc.filter(b=>b.name===SelectedBook)[0].chapters[0];
	let VerseList=[];
	for(let i=1; i<=VerseCount; i++){
		VerseList.push(i);
	}
	PopulateSelectList(VerseList,TopSelector);
}

//This function takes the final value and prints it outerHTML
function GetFinalScripture(TopSelector){
	let selector=document.getElementById("SelectVerse");
	SelectedVerseText=selector.options[selector.selectedIndex].text;
	SelectedVerse=parseInt(SelectedVerseText);
	let finalScripture = document.getElementById("scriptureNewScripture");
	let textAdded="";
	if(ChapterList.length<=1){
		textAdded=document.createTextNode(`${SelectedBook} ${SelectedVerse}`);
	}
	else{
		textAdded=document.createTextNode(`${SelectedBook} ${SelectedChapter}:${SelectedVerse}`);
	}
	finalScripture.appendChild(textAdded);

	//Map results to scripture form
	MapValuesToNewScriptureForm();

	//Disable VerseGroupSelector
	if(SelectedVerse!=VerseCount){
		//Enable Go to verse selector
		document.getElementById("SelectVerseGroup").removeAttribute("disabled");
		let VerseToList=[];
		for(let i=SelectedVerse+1;i<=VerseCount;i++){
			VerseToList.push(i);
		}
		PopulateSelectList(VerseToList,TopSelector);
	}
}

//Add to multiple verse classification
function GetToVerseGroupSpan(){
	let selector=document.getElementById("SelectVerseGroup");
	SelectedVerseToText=selector.options[selector.selectedIndex].text;
	SelectedVerseTo=parseInt(SelectedVerseToText);
	let finalScripture = document.getElementById("scriptureNewScripture");
	finalScripture.innerHTML="";
	let textAdded="";
	if(ChapterList.length<=1){
		textAdded=document.createTextNode(`${SelectedBook} ${SelectedVerse}-${SelectedVerseTo}`);
	}
	else{
		textAdded=document.createTextNode(`${SelectedBook} ${SelectedChapter}:${SelectedVerse}-${SelectedVerseTo}`);
	}

	finalScripture.appendChild(textAdded);


	//Map results to scripture form
	MapValuesToNewScriptureForm();
}

//Function to clear all values
function ClearAllValuesBookLevel(){
	//Clear all global variables
	SelectedBook="";
	ChapterList=[];
	
	
	//Clear the chapter and verse select lists
	removeOptions(document.getElementById("SelectChapter"));
	
	//disable the chapter and verse selectors
	document.getElementById("SelectChapter").setAttribute("disabled","disabled");

	ClearAllValuesChapterLevel();
	ClearAllValuesVerseLevel();
}

function ClearAllValuesChapterLevel(){
	//Clear all global variables
	SelectedChapter=null;
	VerseCount=null;

	//Clear the chapter and verse select lists
	removeOptions(document.getElementById("SelectVerse"));
	
	//disable the chapter and verse selectors
	document.getElementById("SelectVerseGroup").setAttribute("disabled","disabled");
}

function ClearAllValuesVerseLevel(){

	//Clear all global variables
	SelectedVerse=null;

	//Clear the chapter and verse select lists
	removeOptions(document.getElementById("SelectVerseGroup"));

	//remove final scripture
	let finalScripture = document.getElementById("scriptureNewScripture");
	finalScripture.innerHTML = "";

	//Disable Save Changes Button

}



////////////////////
//Base Functions
////////////////////

//Base function to populate list
function PopulateSelectList(BindedList, SelectorName){
	let select = document.getElementById(SelectorName);
	let options = BindedList;

	for(let i = 0; i < options.length; i++) {
		let opt = options[i];
		let el = document.createElement("option");
		el.textContent = opt;
		el.value = opt;
		select.appendChild(el);
	}
}

//Function to remove options
function removeOptions(selectElement) {
   var i, L = selectElement.options.length - 1;
   for(i = L; i >= 0; i--) {
      selectElement.remove(i);
   }
}

////////////////////////
//Added Integration Functions
////////////////////////

//Map final scripture values to Scriptural Select Form
function MapValuesToNewScriptureForm() {

	//Set Book
	document.getElementById('scriptureNewBook').setAttribute("value", SelectedBook);
	//Set Chapter
	document.getElementById('scriptureNewChapter').setAttribute("value", SelectedChapter);
	//Set Verse
	document.getElementById('scriptureNewVerse').setAttribute("value", SelectedVerse);

	//Enable Save button
	//TODO: Add Enable Save button
}


//TODO: First value cannot be selected: this needs to be fixed.  There is an issue with the event "change".