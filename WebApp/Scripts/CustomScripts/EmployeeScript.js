(function ()
{
    "use strict";

    function DayInitializer()
    {
        for (var i = 1; i < 32; i++)
        {
            //var option = document.createElement("option");
            //var node = document.createTextNode(i);
            //var sel = document.getElementById("dayBirth");

            //option.appendChild(node);
            //sel.appendChild(option);

            $("#dayBirth").append($("<option />").val(i).text(i));
        }
    }

    function MonthInitializer()
    {
        var months = {
            0: "January",
            1: "February",
            2: "March",
            3: "April",
            4: "May",
            5: "June",
            6: "July",
            7: "August",
            8: "September",
            9: "October",
            10: "November",
            11: "December"
        };

        //var sel = document.getElementById("monthBirth");

        for (var index in months)
        {
            //sel.options[sel.options.length] = new Option(months[index], index);

            $("#monthBirth").append($("<option />").val(index).text(months[index]));
        }
    }

    function YearInitializer()
    {
        for (var i = 1950; i < 2003; i++)
        {
            //var option = document.createElement("option");
            //var node = document.createTextNode(i);
            //var sel = document.getElementById("yearBirth");

            //option.appendChild(node);
            //sel.appendChild(option);

            $("#yearBirth").append($("<option />").val(i).text(i));
        }
    }

    function SendRequest()
    {
        if ($("#firstName").val() != "" && $("#lastName").val() != "" && $("#dayBirth").val() != "empty" && $("#monthBirth").val() != "empty" && $("#yearBirth").val() != "empty" && $("#educationLevel").val() != 0)
        {
            var day = $("#dayBirth option:selected").val();
            var month = $("#monthBirth option:selected").val();
            var year = $("#yearBirth option:selected").val();

            var newEmployee = {
                firstname: $("#firstName").val(),
                lastname: $("#lastName").val(),
                patronymic: $("#patronymic").val(),
                birthday: new Date(year, month, day),
                educationLevel: $("#educationLevel option:selected").text(),
                educationDegree: $("#educationDegree").val(),
                registrationDate: new Date()
            };

            $.ajax({
                type: "post",
                url: "/AddEmployee/InsertEmployee",
                data: JSON.stringify(newEmployee),
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (response)
                {
                    if (response.success)
                    {
                        window.location.href = "/MainPage/Index";
                    }
                },
                error: function (xhr, ajaxOptions, thrownError)
                {
                    alert(xhr.status);
                    alert(xhr.responseText);
                    alert(thrownError);
                }
            });
        }
        else
        {
            alert("First name, last name, birthday, education are required to fill.");
        }
    }

    function SetFocus()
    {
        $("#firstName").focus();
    }

    $(document).ready(function ()
    {
        DayInitializer();
        MonthInitializer();
        YearInitializer();

        SetFocus();

        $("#buttonOk").click(function ()
        {
            SendRequest();
        });
    })
}());