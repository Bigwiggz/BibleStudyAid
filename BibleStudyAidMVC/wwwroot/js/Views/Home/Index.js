/*
 * Index Home Page
 */

//////////////////////////////////////////
//ChartJS Project Index Page
//////////////////////////////////////////


//CPI ChartsJS
let chartTitle = 'Projects by Date';

//---------------------
//- STACKED BAR CHART -
//---------------------


function newDate(days) {
	return moment().add(days, 'd');
}

let data={
	labels: [newDate(-11), newDate(-3), newDate(2), newDate(3), newDate(4), newDate(5), newDate(6)],
	datasets: [
		{
			label: "My First dataset",
			data: [1, 3, 4, 2, 1, 4, 2],
			backgroundColor: "rgba(20,255,20,0.5)"
		},
		{
			label: "My Second dataset",
			data: [4, 2, 3, 1, 2, 3, 2],
			backgroundColor: "rgba(20,0,255,0.5)"
		}
	]
};

var stackedBarChartCanvas = document.getElementById("projectLineChart").getContext('2d');
var stackedBarChartData = data;

let	stackedBarChartOptions = {
	responsive: true,
	maintainAspectRatio: false,
	scales: {
		xAxes: [{
			stacked: true,
		}],
		yAxes: [{
			stacked: true
		}]
	},
	plugins: {
		title: {
			display: true,
			text: chartTitle,
			font: {
				size: 20
			}
		}
	}
};

new Chart(stackedBarChartCanvas, {
	type: 'bar',
	data: stackedBarChartData,
	options: stackedBarChartOptions
});
 


/*
//Get unique record types
let myRecordTypes = results.map(item => item.recordType)
	.filter((value, index, self) => self.indexOf(value) === index);

let datasets = [];

myRecordTypes.forEach(uniqueDataset => {
	let entryDataset = {};
	entryDataset.label = uniqueDataset;

	datasets.push(entryDataset);
});
*/



/*
ShowLineChart(getCPIChartData);

//Line Chart

function ShowLineChart(results) {

	let myRecordType = [];
	let myDates = [];

	results.sort((a, b) => new Date(a.dateOfRecord) - new Date(b.dateOfRecord));

	for (let i = 0; i < results.length; i++) {
		myRecordType.push(parseFloat(results[i].recordType));
		console.log(parseFloat(results[i].recordType));
		myDates.push(results[i].dateOfRecord.slice(0, 10));
	}

	let popCanvasName = document.getElementById("lineChart");
	new Chart("lineChart", {
		type: 'line',
		data: {
			labels: myDates,
			datasets: [{
				label: 'CPI Index data',
				data: myRecordType,
				backgroundColor: "rgba(0,0,255,1.0)"
			}]
		},
		options: {
			responsive: true,
			scales: {
				yAxes: [{
					ticks: {
						beginAtZero: true,
						min: 0,
						max: 100
					}
				}]
			},
			plugins: {
				title: {
					display: true,
					text: chartTitle,
					font: {
						size: 20
					}
				}
			}
		}
	});
}
*/