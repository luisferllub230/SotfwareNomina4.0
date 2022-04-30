function menuu() {
    document.getElementById('menu').classList.toggle('min')
}

document.getElementById('btn__menu').onclick = function (e) {
    e.preventDefault();
    menuu()
}
function vermenu() {
    document.getElementById('menu__option').classList.toggle('vermenu')
}

document.getElementById('btn__menu__option').onclick = function (e) {
    e.preventDefault();
    vermenu();
}

var ctx = document.getElementById('my').getContext("2d")
var my = new Chart(ctx, {
    type: "bar",
    data: {
        labels: ['col1', 'col3', 'col2'],
        datasets: [{
            label: "Nominas",
            data: [10, 7, 15],
            backgroundColor: [
                '#e74c3c', ' #28b463 ', '#8e44ad'
            ]
        }]
    }
})