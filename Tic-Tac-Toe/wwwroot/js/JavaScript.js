var turn = 'x';
$(".box").on("click", function () {
    if ($(this).is(':empty') && turn === 'x') {
        $(this).html('X').css({ backgroundColor: "#580817" });
        turn = 'o';
        var message = '';
        var field = [];
        for (var i = 0; i < 9; i++) {
            var j = "#" + i;
            field[i] = $(j).text();
        }
        $.post({
            type: "POST",
            url: '/TicTac/UsersTurn',
            data: JSON.stringify(field),
            contentType: "application/json",
            dataType: "json",
            success: function (msg) {
                message = msg;
            }
        });
        if (message === 'Success') {

        }
    }
    else if ($(this).is(':empty')){
        $(this).html('O').css({ backgroundColor: "#a25a01" });
        turn = 'x';
    }
});