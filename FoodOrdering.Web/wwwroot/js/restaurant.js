$(document).ready(function () {
    $("#success-dialog").dialog({
        autoOpen: false,
        buttons: {
            OK: function () {
                $(this).dialog("close");
                location.reload();
            }
        },
    });
    $("#failure-dialog").dialog({
        autoOpen: false,
        buttons: {
            OK: function () {
                $(this).dialog("close");
            }
        },
    });
    $("#cbChecked").click(function () {
        $("#failure-dialog").dialog("open");
        $("#success-dialog").dialog("close");
    });
    $("input[type='checkbox']").change(function () {
        var cbChecked = new Array();

        $("input[type='checkbox']:checked").each(function () {
            cbChecked[cbChecked.length] = this.value;
        });

        if (cbChecked.length == 0) {
            $("button#cbChecked").html("Order");
            $("#cbChecked").click(function () {
                $("#failure-dialog").dialog("open");
                $("#success-dialog").dialog("close");
            });
        }
        else {
            $("button#cbChecked").html("Order - " + "R" + $.sum(cbChecked));
            $("#cbChecked").click(function () {
                $("#success-dialog").dialog("open");
                $("#failure-dialog").dialog("close");
            });
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