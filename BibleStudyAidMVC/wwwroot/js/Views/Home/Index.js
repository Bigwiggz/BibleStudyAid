/*
 * Index Home Page
 */

/////////////////////////////
//Google Calendar Chart
/////////////////////////////

//Google Chart Global Variables
let startDate = new Date(new Date().setFullYear(new Date().getFullYear() - 1));
let endDate = new Date();
let googleChartFakeCalendarObjects = [];
let googleChartCalendarObjects = restructureChartData();
generateFakeData();

//Initialize Google Calendar
google.charts.load("current", { packages: ["calendar"] });
google.charts.setOnLoadCallback(drawCalendarChart);

//Function to generate fake Data
function generateFakeData() {
    let dateEventObject = {};

    for (var d = startDate; d <= endDate; d.setDate(d.getDate() + 1)) {
        let randomNumber = Math.floor(Math.random() * 101);
        //google-charts
        googleChartFakeCalendarObjects.push([new Date(d), randomNumber]);
    }

    return dateEventObject;
};

//
function restructureChartData() {
    let calendarObjectsToChart = getProjectChartData.timeEntryProjectsList;
    //TODO: finish restructuring data for google charts
    let googleChartArraysList = [];
    let dateEntryList = [];
    for (var d = startDate; d <= endDate; d.setDate(d.getDate() + 1)) {
        //google-charts
        googleChartArraysList.push([new Date(d), 0]);
    };

    calendarObjectsToChart.forEach(dateExamined => {
        let dateObject = new Date(dateExamined.dateOfRecord.split("T")[0]);

        if (dateEntryList.includes(dateObject) === true) {
            let indexOfRecord = dateEntryList.indexOf(dateObject);
            googleChartArraysList[indexOfRecord][1] += 1;
        };
        if (dateEntryList.length == 0 || dateEntryList.includes(dateObject) === false) {
            let addGoogleChartArray = [dateObject, 1];
            googleChartArraysList.push(addGoogleChartArray);
            dateEntryList.push(dateObject);
        };
    });

    return googleChartArraysList;
};


//Draw Calendar Chart
function drawCalendarChart() {
    var dataTable = new google.visualization.DataTable();
    dataTable.addColumn({ type: 'date', id: 'Date' });
    dataTable.addColumn({ type: 'number', id: 'Won/Loss' });
    dataTable.addRows(googleChartCalendarObjects);

    var chart = new google.visualization.Calendar(document.getElementById('google-charts'));

    var options = {
        title: "Daily Bible Reading",
        height: 350,
        calendar: {
            cellColor: {
                stroke: '#76a7fa',
                strokeOpacity: 0.5,
                strokeWidth: 1,
            }
        }
    };

    chart.draw(dataTable, options);
}

/////////////////////////////
//Google Bar Chart
/////////////////////////////

google.charts.load('current', { packages: ['corechart', 'bar'] });
google.charts.setOnLoadCallback(drawMultSeries);

function drawMultSeries() {
    var data = google.visualization.arrayToDataTable([
        ['City', '2010 Population', '2000 Population'],
        ['New York City, NY', 8175000, 8008000],
        ['Los Angeles, CA', 3792000, 3694000],
        ['Chicago, IL', 2695000, 2896000],
        ['Houston, TX', 2099000, 1953000],
        ['Philadelphia, PA', 1526000, 1517000]
    ]);

    var options = {
        title: 'Population of Largest U.S. Cities',
        chartArea: { width: '50%' },
        hAxis: {
            title: 'Total Population',
            minValue: 0
        },
        vAxis: {
            title: 'City'
        }
    };

    var chart = new google.visualization.BarChart(document.getElementById('tabs-bar-chart'));
    chart.draw(data, options);
}