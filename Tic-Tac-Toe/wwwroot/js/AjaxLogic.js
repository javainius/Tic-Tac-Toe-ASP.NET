$('.alert').hide();

$(".box").on("click", function () {
    if ($(this).text() === ' ' && gameMode !== null && !gameOver) {
        $(this).html('X').css({ backgroundColor: "#580817" });
        var boxId = this.id;
        var movePositions = ("" + boxId.split()).split("");
        var userMove = {};
        userMove.MovePositions = movePositions.map(function (x) {
            return parseInt(x, 10);
        });
        userMove.GameMode = gameMode;
       
        $.post({
            type: "POST",
            url: '/Home/UpdateState',
            data: JSON.stringify(userMove),
            contentType: "application/json",
            dataType: "json",
            success: function (table) {
                CheckStatus(table.status);
                
                $('#00').html(table.rows[0].firstElement);

                $('#01').html(table.rows[0].secondElement);

                $('#02').html(table.rows[0].thirdElement);

                $('#10').html(table.rows[1].firstElement);

                $('#11').html(table.rows[1].secondElement);

                $('#12').html(table.rows[1].thirdElement);

                $('#20').html(table.rows[2].firstElement);

                $('#21').html(table.rows[2].secondElement);

                $('#22').html(table.rows[2].thirdElement);

                ChangeColors();
                
            }
        });

    }
});
ChangeColors();

