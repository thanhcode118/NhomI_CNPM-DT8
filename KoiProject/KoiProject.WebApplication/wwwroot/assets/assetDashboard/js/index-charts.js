'use strict';

window.chartColors = {
    green: '#75c181',
    gray: '#a9b5c9',
    text: '#252930',
    border: '#e7e9ed'
};

// Random data generators
function getRandomWinRate() {
    // Generate random number between 60 and 95 for win rates
    return Math.floor(Math.random() * (95 - 60 + 1)) + 60;
}

function getRandomOdds() {
    // Generate random number between 1.5 and 4 for betting odds
    return (Math.random() * (4 - 1.5) + 1.5).toFixed(1);
}

//Chart.js Line Chart - KOI Winner Rate
var lineChartConfig = {
    type: 'line',
    data: {
        labels: ['Day 1', 'Day 2', 'Day 3', 'Day 4', 'Day 5', 'Day 6', 'Day 7'],
        datasets: [{
            label: 'Current week',
            fill: false,
            backgroundColor: window.chartColors.green,
            borderColor: window.chartColors.green,
            data: Array.from({ length: 7 }, getRandomWinRate),
        }, {
            label: 'Previous week',
            borderDash: [3, 5],
            backgroundColor: window.chartColors.gray,
            borderColor: window.chartColors.gray,
            data: Array.from({ length: 7 }, getRandomWinRate),
            fill: false,
        }]
    },
    options: {
        responsive: true,
        aspectRatio: 1.5,
        legend: {
            display: true,
            position: 'bottom',
            align: 'end',
        },
        title: {
            display: true,
            text: 'KOI Winner Rate',
            fontSize: 16,
            padding: 20
        },
        tooltips: {
            mode: 'index',
            intersect: false,
            titleMarginBottom: 10,
            bodySpacing: 10,
            xPadding: 16,
            yPadding: 16,
            borderColor: window.chartColors.border,
            borderWidth: 1,
            backgroundColor: '#fff',
            bodyFontColor: window.chartColors.text,
            titleFontColor: window.chartColors.text,
            callbacks: {
                label: function (tooltipItem, data) {
                    return tooltipItem.value + '%';
                }
            },
        },
        scales: {
            xAxes: [{
                display: true,
                gridLines: {
                    drawBorder: false,
                    color: window.chartColors.border,
                }
            }],
            yAxes: [{
                display: true,
                gridLines: {
                    drawBorder: false,
                    color: window.chartColors.border,
                },
                ticks: {
                    beginAtZero: true,
                    max: 100,
                    stepSize: 10,
                    callback: function (value) {
                        return value + '%';
                    }
                },
            }]
        }
    }
};

// Chart.js Bar Chart - KOI Betting Odds
var barChartConfig = {
    type: 'bar',
    data: {
        labels: ['Day 1', 'Day 2', 'Day 3', 'Day 4', 'Day 5', 'Day 6', 'Day 7'],
        datasets: [{
            label: 'Odds',
            backgroundColor: window.chartColors.green,
            borderColor: window.chartColors.green,
            borderWidth: 1,
            maxBarThickness: 16,
            data: Array.from({ length: 7 }, getRandomOdds)
        }]
    },
    options: {
        responsive: true,
        aspectRatio: 1.5,
        legend: {
            position: 'bottom',
            align: 'end',
        },
        title: {
            display: true,
            text: 'KOI Betting Odds',
            fontSize: 16,
            padding: 20
        },
        tooltips: {
            mode: 'index',
            intersect: false,
            titleMarginBottom: 10,
            bodySpacing: 10,
            xPadding: 16,
            yPadding: 16,
            borderColor: window.chartColors.border,
            borderWidth: 1,
            backgroundColor: '#fff',
            bodyFontColor: window.chartColors.text,
            titleFontColor: window.chartColors.text,
            callbacks: {
                label: function (tooltipItem, data) {
                    return tooltipItem.value + 'x';
                }
            }
        },
        scales: {
            xAxes: [{
                display: true,
                gridLines: {
                    drawBorder: false,
                    color: window.chartColors.border,
                }
            }],
            yAxes: [{
                display: true,
                gridLines: {
                    drawBorder: false,
                    color: window.chartColors.border,
                },
                ticks: {
                    beginAtZero: true,
                    max: 5,
                    stepSize: 0.5,
                    callback: function (value) {
                        return value + 'x';
                    }
                }
            }]
        }
    }
};

// Generate charts on load
window.addEventListener('load', function () {
    // Update chart titles in HTML
    document.querySelectorAll('.app-card-title').forEach(function (element) {
        if (element.textContent === 'Line Chart Example') {
            element.textContent = 'Tỉ lệ chiến thắng';
        } else if (element.textContent === 'Bar Chart Example') {
            element.textContent = 'Tỉ lệ đặt cược';
        }
    });

    // Remove "More charts" links
    document.querySelectorAll('a[href="/html/charts.html"]').forEach(function (element) {
        element.parentElement.remove();
    });

    var lineChart = document.getElementById('canvas-linechart').getContext('2d');
    window.myLine = new Chart(lineChart, lineChartConfig);

    var barChart = document.getElementById('canvas-barchart').getContext('2d');
    window.myBar = new Chart(barChart, barChartConfig);
});