var gameMode = null;
var gameOver = false;
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

function CheckStatus(status) {
    if (status !== "Still playing...") {
        document.getElementById('gameOver').innerHTML = status;
        gameOver = true;
        $('.alert').show();
    }
}

function ChangeColors() {
    for (var i = 0; i < 3; i++) {
        for (var j = 0; j < 3; j++) {
            if ($('#' + i + j).text() === 'X') {
                $('#' + i + j).css({ backgroundColor: "#580817" });
            }
            else if ($('#' + i + j).text() === 'O') {
                $('#' + i + j).css({ backgroundColor: "#a25a01" });
            }
            else {
                $('#' + i + j).css({ backgroundColor: "#34495e" });
            }
        }
    }
}
