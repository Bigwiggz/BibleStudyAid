/*
Leaflet Javascript File
*/



///////////////////////////////////////////
//Create Map with coordinates
///////////////////////////////////////////
let map = L.map('map');//.setView([33.996166, -81.031456], 13);

///////////////////////////////////////////
//Create Global Variables
///////////////////////////////////////////
//Load Information
let importedWorldMapItemsList = JSON.parse('{"type":"FeatureCollection","features":[{"type":"Feature","geometry":{"type":"Point","coordinates":[-71.064544,42.28787]},"properties":{"Id":1,"Color":"#f432ac","Description":"Standard Description","Title":"Generic Title","GeographyType":"Point","FKTableIdandName":"MyId","UpdatedDate":"2022-02-25T00:47:13.5087497Z","Guid":"e6227618-7998-437d-803e-f5f9b5048814","IsDeleted":false}},{"type":"Feature","geometry":{"type":"Point","coordinates":[-84.21112,33.7888]},"properties":{"Id":1,"Color":"#432acb","Description":"Standard Description 2","Title":"Generic Title 2","GeographyType":"Point","FKTableIdandName":"MyId 2","UpdatedDate":"2022-02-25T00:47:13.6112327Z","Guid":"9936db3b-4c2e-4b46-bf63-2cff6e1158ea","IsDeleted":false}}]}');


//Used to display variables
let mapWorldMapItemsList = [];

//used to filter list on input
let filteredWorldMapItemsList = {};

//Saved properties list
let colorProperty = "";
let titleProperty = "";
let DescriptionProperty = "";
let FKTableIdandName = "";


///////////////////////////////////////////
//Add Map Layers
///////////////////////////////////////////

let osm = L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
	attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
})

let googleStreets = L.tileLayer('http://{s}.google.com/vt/lyrs=m&x={x}&y={y}&z={z}', {
	maxZoom: 20,
	subdomains: ['mt0', 'mt1', 'mt2', 'mt3']
});

let googleHybrid = L.tileLayer('http://{s}.google.com/vt/lyrs=s,h&x={x}&y={y}&z={z}', {
	maxZoom: 20,
	subdomains: ['mt0', 'mt1', 'mt2', 'mt3']
});

let googleSat = L.tileLayer('http://{s}.google.com/vt/lyrs=s&x={x}&y={y}&z={z}', {
	maxZoom: 20,
	subdomains: ['mt0', 'mt1', 'mt2', 'mt3']
});

let googleTerrain = L.tileLayer('http://{s}.google.com/vt/lyrs=p&x={x}&y={y}&z={z}', {
	maxZoom: 20,
	subdomains: ['mt0', 'mt1', 'mt2', 'mt3']
});

let greyblank = L.tileLayer('https://server.arcgisonline.com/ArcGIS/rest/services/Canvas/World_Light_Gray_Base/MapServer/tile/{z}/{y}/{x}', {
	attribution: 'Tiles &copy; Esri &mdash; Esri, DeLorme, NAVTEQ',
	maxZoom: 16
});

let blockMap = L.tileLayer('https://server.arcgisonline.com/ArcGIS/rest/services/World_Street_Map/MapServer/tile/{z}/{y}/{x}', {
	attribution: 'Tiles &copy; Esri &mdash; Source: Esri, DeLorme, NAVTEQ, USGS, Intermap, iPC, NRCAN, Esri Japan, METI, Esri China (Hong Kong), Esri (Thailand), TomTom, 2012'
});

osm.addTo(map);

//import list of locations
filteredWorldMapItemsList = importedWorldMapItemsList;

//Add scale to map
L.control.scale({ position: 'bottomright' }).addTo(map);



///////////////////////////////////////////
//Add World Map Items
///////////////////////////////////////////
let geoAuxParcel = L.geoJSON(filteredWorldMapItemsList, {
	style: function (feature) {
		return {
			color: `${feature.properties.Color}`,
			fillColor: `${feature.properties.Color}`,
			fill: true,
			fillOpacity: 0.2
		}
	},
	onEachFeature: function (feature, layer) {
		layer.bindTooltip(feature.properties.Title, {
			permanent: true,
			direction: "center",
			className: "WorldMapItemLabel"
		});
		layer.on('click', function () {
			let polygonProperties = feature.properties;
			LoadItemInformation(polygonProperties);
		});
	}
});

//Add Default Layer to Map
geoAuxParcel.addTo(map);
//bound to layer set
map.fitBounds(geoAuxParcel.getBounds(), { padding: [10, 10] });


///////////////////////////////////////////
//Add Map Layer Controller
///////////////////////////////////////////

//Base Maps to Layer
let baseMaps = {
	"OSM": osm,
	"Google Streets": googleStreets,
	"Google Satelite": googleSat,
	"Google Hybrid": googleHybrid,
	"Block Map": blockMap,
	"Gray": greyblank
};

//Shapes to Layer
let overlayMaps = {
	"Display World Map Items": geoAuxParcel
};

L.control.layers(baseMaps, overlayMaps).addTo(map);


///////////////////////////////////////////
//Function to add input information
///////////////////////////////////////////

function LoadItemInformation(properties) {


	//Append html table information
	const InformationTable = document.getElementById("InformationTableBody");
	InformationTable.textContent = "";

	let htmlTable = "";

	for (var key of Object.keys(properties)) {
		let columnField = key.replace(/([A-Z])/g, ' $1').trim();
		let columnValue = properties[key];

		htmlTable +=
			`
		<tr>
			<td><b>${columnField}</b></td>
			<td>${columnValue}</td>
		</tr>
		`
	}

	//Append html table information
	InformationTable.insertAdjacentHTML('afterbegin', htmlTable);

	//turn visibility of element on to display table
	document.getElementById("table-information-section").style.visibility = "visible";

	//clear input array after information is posted
	result = [];

	//scroll to Item Information Table
	document.getElementById("table-information-section").scrollIntoView();

}

///////////////////////////////////////////
//Add Leaflet Drawing Controls 
///////////////////////////////////////////




map.pm.addControls({
	position: 'topleft',
	editMode: true,
	removalMode: true,
	drawMarker: false,
	drawPolygon: false,
	drawPolyline: false,
	drawRectangle: false,
	drawCircle: false,
	drawCircleMarker: false
});




/*
//Function to get geoJSON after shape has been created
function generateGeoJson(){
map.on('pm:create',(e) {
  e.layer.on('pm:edit', ({ layer }) => {
	// layer has been edited
	console.log(layer.toGeoJSON());
  })
});
*/

/*
Function to clear all shapes


map.eachLayer(function(layer){
	 if (layer._path != null) {
	layer.remove()
  }
});

*/




function findLayers(map) {
	var layers = [];
	map.eachLayer(layer => {
		if (
			layer instanceof L.Polyline ||
			layer instanceof L.Marker ||
			layer instanceof L.Circle ||
			layer instanceof L.CircleMarker
		) {
			layers.push(layer);
		}
	});

	// filter out layers that don't have the leaflet-geoman instance
	layers = layers.filter(layer => !!layer.pm);

	// filter out everything that's leaflet-geoman specific temporary stuff
	layers = layers.filter(layer => !layer._pmTempLayer);

	return layers;
};




///////////////////////////////////////////
//Add new World Map Item
///////////////////////////////////////////
/*
1) add button is clicked
2) Information is filled out on modal and validated
3) Information is saved globally
4) Draw buttons are added to the map
5) Properties are added to feature group
6) geojson string is posted to controller
7) new page is rendered with saved geojson
*/

//Create Events

//On create geometry
map.on('pm:create', e => {
	generateGeoJson();
	ClearAllDrawingLayers();
	clearAllModalPropertiesForWorldMapItem();
});

//On update modal properties
document.getElementById("CreateModalPropertiesSaveModalButton").addEventListener("click", e => {
	getModalPropertiesToCreateWorldMapItem();
	addDrawButtonsToMap();
	
});

// Top level functions
function generateGeoJson() {
	var fg = L.featureGroup();
	var layers = findLayers(map);
	//Get last drawn layer
	fg.addLayer(layers.slice(-1)[0]);
	/*
	layers.forEach(function (layer) {
		fg.addLayer(layer
	});
	*/
	var data = fg.toGeoJSON();
	addPropertiesToFeatureGroup(data);
	console.log(data);
	console.log(JSON.stringify(data));
	addgeoJSONStringToFormForSubmission(JSON.stringify(data));
}


function ClearAllDrawingLayers() {
	map.eachLayer(function (layer) {
		if (layer._path != null) {
			layer.remove()
		}
	});
};


function addPropertiesToFeatureGroup(data) {
	data.features.forEach(x => {
		x.properties = {
			color: colorProperty,
			title: titleProperty,
			description: DescriptionProperty,
			fKTableIdandName:FKTableIdandName
		};
	})
}

function addgeoJSONStringToFormForSubmission(data) {
	//Set geostring attribute
	document.getElementById("geoJsonString").setAttribute("value", data);
	//Activate button
	document.getElementById("createWorldMapItemButton").removeAttribute("disabled");

}

function getModalPropertiesToCreateWorldMapItem() {
	colorProperty = document.getElementById("colorModal").value;
	titleProperty = document.getElementById("titleModal").value;
	DescriptionProperty = document.getElementById("descriptionModal").value;
	FKTableIdandName = "1tblDailyBibleReading";
	//TODO: Fix this
}

function clearAllModalPropertiesForWorldMapItem() {
	colorProperty = "";
	titleProperty = "";
	DescriptionProperty = "";
	FKTableIdandName = "";
}

function addDrawButtonsToMap() {
	map.pm.addControls({
		position: 'topleft',
		drawMarker: true,
		drawPolygon: true,
		drawPolyline: true,
		drawRectangle: true,
		drawCircle: true,
		drawCircleMarker: true
	});
}


//FETCH FUNCTION

// Example POST method implementation:
async function postData(url = '', data = {}) {
	// Default options are marked with *
	const response = await fetch(url, {
		method: 'POST', // *GET, POST, PUT, DELETE, etc.
		//mode: 'cors', // no-cors, *cors, same-origin
		//cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
		credentials: 'include', // include, *same-origin, omit
		headers: {
			'Accept': 'application/json; charset=utf-8',
			'Content-Type': 'application/json; charset=utf-8'
			// 'Content-Type': 'application/x-www-form-urlencoded',
		},
		//redirect: 'follow', // manual, *follow, error
		//referrerPolicy: 'no-referrer', // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
		body: JSON.stringify(data) // body data type must match "Content-Type" header
	});
	return response.json(); // parses JSON response into native JavaScript objects
}


