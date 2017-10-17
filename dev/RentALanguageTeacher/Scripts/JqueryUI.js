//Jquery UI
$(function () {

    $("#accordion").accordion();

    var availableTags = [
        "ActionScript",
        "AppleScript",
        "Asp",
        "BASIC",
        "C",
        "C++",
        "Clojure",
        "COBOL",
        "ColdFusion",
        "Erlang",
        "Fortran",
        "Groovy",
        "Haskell",
        "Java",
        "JavaScript",
        "Lisp",
        "Perl",
        "PHP",
        "Python",
        "Ruby",
        "Scala",
        "Scheme"
    ];

    $("#autocomplete").autocomplete({
        source: availableTags
    });

    $("#button").button();

    $("#radioset").buttonset();

    $("#tabs").tabs();

    $("#dialog").dialog({
        autoOpen: false,
        width: 400,
        buttons: [
            {
                text: "Ok",
                click: function () {
                    $(this).dialog("close");
                }
            },
            {
                text: "Cancel",
                click: function () {
                    $(this).dialog("close");
                }
            }
        ]
    });

    // Link to open the dialog
    $("#dialog-link").click(function (event) {
        $("#dialog").dialog("open");
        event.preventDefault();
    });

    $("#datepicker").datepicker({
        inline: true
    });

    $("#slider").slider({
    });






    $("#progressbar").progressbar({
        value: 20
    });

    $(function () {
        var spinner = $("#spinner").spinner();

        $("#disable").click(function () {
            if (spinner.spinner("option", "disabled")) {
                spinner.spinner("enable");
            } else {
                spinner.spinner("disable");
            }
        });
        $("#destroy").click(function () {
            if (spinner.data("ui-spinner")) {
                spinner.spinner("destroy");
            } else {
                spinner.spinner();
            }
        });
        $("#getvalue").click(function () {
            alert(spinner.spinner("value"));
        });
        $("#setvalue").click(function () {
            spinner.spinner("value", 5);
        });


    });

    $(function () {
        $(document).tooltip();
    });

    // Hover states on the static widgets
    $("#dialog-link, #icons li").hover(
        function () {
            $(this).addClass("ui-state-hover");
        },
        function () {
            $(this).removeClass("ui-state-hover");
        }
    );
});