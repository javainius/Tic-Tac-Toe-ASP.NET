var gameMode = null;
function NewGame() {
    document.getElementById('gameModes').innerHTML =
        '<div> pick game mode:</div>' +
        '<input type="button" onclick="EasyMode()" class="btn btn-info easy" value="Easy" id="btnClickEasy" />'+ '<p> <p/>' +
        '<input type="button" onclick="HardMode()" class="btn btn-info hard" value="Hard" id="btnClickHard" />';
}
function EasyMode() {
    document.getElementById("btnClickEasy").style.backgroundColor = "#000000";
    gameMode = 'easy';
    document.getElementById("btnClickHard").disabled = true;
}

function HardMode() {
    document.getElementById("btnClickHard").style.backgroundColor = "#000000";
    gameMode = 'hard';
    document.getElementById("btnClickEasy").disabled = true;
}
function checkStatus(status) {
    if (status !== "Still playing...") {
        document.getElementById('gameOver').innerHTML = status;
        $('.alert').show();
    }
}
function sleep(miliseconds) {
    var currentTime = new Date().getTime();

    while (currentTime + miliseconds >= new Date().getTime()) {
    }
}