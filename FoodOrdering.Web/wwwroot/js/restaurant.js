$(document).ready(function () {
    $("input[type='checkbox']").change(function () {
        var cbChecked = new Array();

        $("input[type='checkbox']:checked").each(function () {
            cbChecked[cbChecked.length] = this.value;
        });

        if (cbChecked.length == 0) {
            $("button#cbChecked").html("Order");
        }
        else {
            $("button#cbChecked").html("Order - " + "R" + $.sum(cbChecked));
        }
    });

    $.sum = function (arr) {
        var r = 0;
        $.each(arr, function (i, v) {
            r += +v;
        });
        return r;
    }
});