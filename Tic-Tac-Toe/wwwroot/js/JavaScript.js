
$(".box").on("click", function () {
    if ($(this).is(':empty') && gameMode !== null) {
        $(this).html('X').css({ backgroundColor: "#580817" });
       
        var boxId = this.id.split();
        var movePositions = ("" + boxId).split("");
        var userMove = {};
        userMove.MovePositions = movePositions.map(function (x) {
            return parseInt(x, 10);
        });
        userMove.GameMode = gameMode; 
        
        $.post({
            type: "POST",
            url: '/TicTac/UpdateState',
            data: JSON.stringify(userMove),
            contentType: "application/json",
            dataType: "json",
            success: function (table) {
                $('#00').html(table.rows[0].firstElement);

                $('#01').html(table.rows[0].secondElement);

                $('#02').html(table.rows[0].thirdElement);

                $('#10').html(table.rows[1].firstElement);

                $('#11').html(table.rows[1].secondElement);

                $('#12').html(table.rows[1].thirdElement);

                $('#20').html(table.rows[2].firstElement);

                $('#21').html(table.rows[2].secondElement);

                $('#22').html(table.rows[2].thirdElement);

                checkStatus(table.Status)
                ChangeColors();
                var StillPlaying = false;
                for (var i = 0; i < 3; i++) {
                    for (var j = 0; j < 3; j++) {
                        if ($('#' + i + j).text() === 'X') {
                            StillPlaying = true;
                        }
                    }
                }
                if (!StillPlaying) {
                    gameMode = null;

                    NewGame();
                }
            }
        });

    }
});
ChangeColors();

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