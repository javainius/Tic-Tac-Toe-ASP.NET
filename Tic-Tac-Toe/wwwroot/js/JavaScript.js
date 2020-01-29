var turn = 'x';
$(".box").on("click", function () {
    if ($(this).is(':empty') && turn === 'x') {
        $(this).html('X').css({ backgroundColor: "#580817" });
        turn = 'o';
        var message = '';
        $.post({
            type: "POST",
            url: '/TicTac/UpdateState',
            data: JSON.stringify(this.id),
            contentType: "application/json",
            dataType: "json",
            success: function (gameState) {
                alert(gameState);
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