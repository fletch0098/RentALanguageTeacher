﻿function pageLoad() {

    $(function () {
        //Format spinner to a list
        $(document).ready(function () {
            $.widget("ui.formatSpinner", $.ui.spinner, {
                options: {
                },
                _parse: function (value) {
                    if (typeof value === "string") {
                        return this.options.values.indexOf(value);
                    }
                    return value;
                },
                _format: function (value) {
                    //wrap around
                    if (value < 0) {
                        value = this.options.count - 1;
                    }
                    if (value > this.options.count - 1) {
                        value = 0;
                    }
                    var format = this.options.values[value];
                    return format;
                },
            })
        });

        //paper type spinner
        var arrPaperTypes = ["Week", "Month", "Year"];

        $(document).ready(function () {
            $("#SpinnerPeriod").formatSpinner({
                values: arrPaperTypes,
                count: arrPaperTypes.length
            });
        });

        $(function () {
            
 
        });
        $(document).ready(function () {

            $('#FrequencySlider').slider();
            $("#StartingDate").datepicker({
                inline: true
            });
            $("#StartingDate").datepicker("option", "dateFormat", "yy-mm-dd");

        });

        $(document).ready(function () {
            $("#FrequencySlider").slider({
                range: "min",
                value: 7,
                min: 1,
                max: 50,
                slide: function (event, ui) {
                    $("#FrequencyValue").val(ui.value);
                }
            });
        });

        $(function () {
            $("#FrequencySpinner").spinner({
                spin: function (event, ui) {
                    if (ui.value > 50) {
                        $(this).spinner("value", 1);
                        return false;
                    } else if (ui.value < 1) {
                        $(this).spinner("value", 50);
                        return false;
                    }
                }
            });
        });

        $(document).ready(function () {
            $("#LevelSlider").slider({
                range: "min",
                value: 0,
                min: 1,
                max: 4,
                slide: function (event, ui) {

                    if (ui.value == 1) {
                        $("#LevelValue").val("Total Beginner - I need a teacher that can speak some English");
                        $('#SpanishLevel').val("1");
                    };
                    if (ui.value == 2) {
                        $("#LevelValue").val("Beginner - I have learnt Spanish before, but not much");
                        $('#SpanishLevel').val("2");
                    };
                    if (ui.value == 3) {
                        $("#LevelValue").val("Intermediate - I can hold a conversation in Spanish");
                        $('#SpanishLevel').val("3");
                    };
                    if (ui.value == 4) {
                        $("#LevelValue").val("Advanced - I speak fluently in Spanish");
                        $('#SpanishLevel').val("4");
                    };


                }
            });
        });

       
        $(function () {
            $("#MailList").dialog({
                autoOpen: false,
                resizable: false,
                height: 460,
                width: 425,
                modal: true,
                dialogClass: 'no-close',

                buttons: {
                    //"Save": function () {



                    //},
                }
            });
        });


        $(function () {
            $(document).tooltip();
        });

        $("#tabs").tabs();

        $(document).ready(function () {

            $('#LevelSlider').labeledslider({ max: 3, tickInterval: 1 });

        });
    });

}

function BindRequestForm() {

    $(function () {
        //Format spinner to a list
        $(document).ready(function () {
            $.widget("ui.formatSpinner", $.ui.spinner, {
                options: {
                },
                _parse: function (value) {
                    if (typeof value === "string") {
                        return this.options.values.indexOf(value);
                    }
                    return value;
                },
                _format: function (value) {
                    //wrap around
                    if (value < 0) {
                        value = this.options.count - 1;
                    }
                    if (value > this.options.count - 1) {
                        value = 0;
                    }
                    var format = this.options.values[value];
                    return format;
                },
            })
        });

        //paper type spinner
        var arrPaperTypes = ["Week", "Month", "Year"];

        $(document).ready(function () {
            $("#SpinnerPeriod").formatSpinner({
                values: arrPaperTypes,
                count: arrPaperTypes.length
            });
        });

        $(function () {


        });
        $(document).ready(function () {

            $('#FrequencySlider').slider();
            $("#StartingDate").datepicker({
                inline: true
            });
            $("#StartingDate").datepicker("option", "dateFormat", "yy-mm-dd");

        });

        $(document).ready(function () {
            $("#FrequencySlider").slider({
                range: "min",
                value: 7,
                min: 1,
                max: 50,
                slide: function (event, ui) {
                    $("#FrequencyValue").val(ui.value);
                }
            });
        });

        $(function () {
            $("#FrequencySpinner").spinner({
                spin: function (event, ui) {
                    if (ui.value > 50) {
                        $(this).spinner("value", 1);
                        return false;
                    } else if (ui.value < 1) {
                        $(this).spinner("value", 50);
                        return false;
                    }
                }
            });
        });

        $(document).ready(function () {
            $("#LevelSlider").slider({
                range: "min",
                value: 0,
                min: 1,
                max: 4,
                slide: function (event, ui) {

                    if (ui.value == 1) {
                        $("#LevelValue").val("Total Beginner - I need a teacher that can speak some English");
                        $('#SpanishLevel').val("1");
                    };
                    if (ui.value == 2) {
                        $("#LevelValue").val("Beginner - I have learnt Spanish before, but not much");
                        $('#SpanishLevel').val("2");
                    };
                    if (ui.value == 3) {
                        $("#LevelValue").val("Intermediate - I can hold a conversation in Spanish");
                        $('#SpanishLevel').val("3");
                    };
                    if (ui.value == 4) {
                        $("#LevelValue").val("Advanced - I speak fluently in Spanish");
                        $('#SpanishLevel').val("4");
                    };


                }
            });
        });

        $(function () {
            $("#MailList").dialog({
                autoOpen: false,
                resizable: false,
                height: 460,
                width: 425,
                modal: true,
                dialogClass: 'no-close',

                buttons: {
                    //"Save": function () {



                    //},
                }
            });
        });

        $(function () {
            $(document).tooltip();
        });

        $("#tabs").tabs();

        $(document).ready(function () {

            $('#LevelSlider').labeledslider({ max: 3, tickInterval: 1 });

        });
    });

}

function NoThanks() {

    setCookie('RentALanguageTeacherAccount', 'Dismiss', '1');

    $("#MailList").dialog("close");
};

function NoAccount() {

    $(function () {
        $("#MailList").dialog("open");
    });
};

$(function () {
    $("#MailList").dialog({
        autoOpen: false,
        resizable: false,
        height: 460,
        width: 425,
        modal: true,
        dialogClass: 'no-close',

        buttons: {
            //"Save": function () {



            //},
        }
    });
});

$(function () {
    $("#EmailLevelSlider").slider({
        range: "min",
        value: 0,
        min: 1,
        max: 4,
        slide: function (event, ui) {

            if (ui.value == 1) {
                $("#EmailLevelValue").val("Total beginner - I have never learnt Spanish before but would like to start");

            };
            if (ui.value == 2) {
                $("#EmailLevelValue").val("Beginner - I have taken some lessons in Spanish and can somewhat speak");

            };
            if (ui.value == 3) {
                $("#EmailLevelValue").val("Intermediate - I have taken Spanish lessons and can speak pretty fluently in Spanish");

            };
            if (ui.value == 4) {
                $("#EmailLevelValue").val("Advanced - I speak fluently in Spanish");

            };


        }
    });
});

function JoinMailList() {

    var ValidName = !($("#txtName").validationEngine('validate'));
    var ValidEmail = !($("#txtEmail").validationEngine('validate'));

    var IsValid = ValidEmail && ValidName

    if (!IsValid) {
        return;
    }

    var Name = $("#txtName").val();
    var Email = $("#txtEmail").val();
    var SpanishDescription = $("#EmailLevelValue").val();

    var myStringArray = SpanishDescription.split("-");

    var SpanishDescriptionLavel = myStringArray[0];

    var SpanishLevel;
    if (SpanishDescriptionLavel == "Total beginner ") {
        SpanishLevel = 0;
    };
    if (SpanishDescriptionLavel == "Beginner ") {
        SpanishLevel = 1;
    };
    if (SpanishDescriptionLavel == "Intermediate ") {
        SpanishLevel = 2;
    };
    if (SpanishDescriptionLavel == "Advanced ") {
        SpanishLevel = 3;
    };

    var myStringArray = Name.split(" ");
    var arrayLength = myStringArray.length;
    var FirstName = myStringArray[0];
    var LastName = "";
    for (var i = 1; i < arrayLength; i++) {
        LastName = LastName + myStringArray[i] + " ";
    }

    //Call WebMethod
    $.ajax({
        type: "POST",
        url: "/Default.aspx/JoinEmailList",
        data: "{'FirstName': '" + FirstName + "', 'LastName': '" + LastName + "', 'Email': '" + Email + "', 'SpanishLevel': '" + SpanishLevel + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        //Success Function
        success: function (ReturnValue) {

            if (ReturnValue.d == "Success") {
                //setCookie("RentALanguageTeacherAccount", "Email", "735");

                $("#MailList").dialog("close");

                var n = noty({ text: "Thank you for joining us!", type: 'success' });
            }
            else {
                var n = noty({ text: "There was an error, Please Try again", type: 'error' });
            }
        },
        //Error
        error: function (request, status, error) {
            var n = noty({ text: "There was an error, Please Try again", type: 'error' });
        },
    });
};

function DismissMailList() {

    //Call WebMethod
    $.ajax({
        type: "POST",
        url: "/Default.aspx/DismissEmailList",
        //data: "{'FirstName': '" + FirstName + "', 'LastName': '" + LastName + "', 'Email': '" + Email + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        //Success Function
        success: function (ReturnValue) {

            if (ReturnValue.d == "Success") {
                
                $("#MailList").dialog("close");

            }
            else {
               
            }
        },
        //Error
        error: function (request, status, error) {

        },
    });
};

//Cookies Scripts
function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toGMTString();
    document.cookie = cname + "=" + cvalue + "; " + expires;
}

function getCookie(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i].trim();
        if (c.indexOf(name) == 0) return c.substring(name.length, c.length);
    }
    return "";
}