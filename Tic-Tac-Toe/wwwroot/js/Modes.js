var gameMode = null;
function NewGame() {
    document.getElementById('gameModes').innerHTML =
        '<div> pick game mode:</div>' +
        '<input type="button" onclick="EasyMode()" class="btn btn-info easy" value="Easy" id="btnClick" />'+ '<p> <p/>' +
        '<input type="button" onclick="HardMode()" class="btn btn-info hard" value="Hard" id="btnClick" />';
    document.getElementById('currentMode').innerHTML = ' ';
}
function EasyMode() {
    gameMode = 'easy';
    document.getElementsByClassName("hard").disabled = true;
}

function HardMode() {
    gameMode = 'hard';
    document.getElementsByClassName("easy").disabled = true;
}