var turn = 'x';
$(".box").on("click", function () {
    if ($(this).is(':empty') && turn === 'x') {
        $(this).html('X').css({ backgroundColor: "#580817" });
        turn = 'o';
        var message = '';
        var fieldId = this.id;
        $.post({
            type: "POST",
            url: '/TicTac/UsersTurn',
            data: JSON.stringify(fieldId),
            contentType: "application/json",
            dataType: "json",
            success: function (msg) {
                alert(msg);
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