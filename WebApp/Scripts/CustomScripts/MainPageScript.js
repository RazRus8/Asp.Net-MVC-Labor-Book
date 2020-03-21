(function ()
{
    "use strict"

    function ClearFields()
    {
        //clearing fields
        $("#recordOutput").empty();
        $("#recordOutput").append($("<br />"));
        $("#dateOutput").empty();
        $("#dateOutput").append($("<br />"));
        $("#actionOutput").empty();
        $("#actionOutput").append($("<br />"));
        $("#descriptionOutput").empty();
        $("#descriptionOutput").append($("<br />"));
        $("#positionOutput").empty();
        $("#positionOutput").append($("<br />"));
        $("#documentOutput").empty();
        $("#documentOutput").append($("<br />"));
    }

    function ClearSelectRecords()
    {
        // clearing record select
        $("#recordSelect").empty();
        $("#recordSelect").append($("<option />").val(0).text("Select record"));
    }

    function GetEmployees()
    {
        $.ajax({
            type: "post",
            url: "/MainPage/GetEmployees",
            data: null,
            success: function (data)
            {
                var i = 1;

                $.each(data, function ()
                {
                    $("#employeeSelect").append($("<option />").val(this.EmployeeId).text(i++ + " - " + this.FirstName + " " + this.LastName));
                });
            },
            error: function (xhr, ajaxOptions, thrownError)
            {
                alert(xhr.status);
                alert(xhr.responseText);
                alert(thrownError);
            }

        });
    }

    function GetRecords()
    {
        $("#employeeSelect").change(function ()
        {
            if ($("#employeeSelect").val() != 0)
            {
                var id = { selectedEmployeeId: $("#employeeSelect").val() };

                $.ajax({
                    type: "post",
                    url: "/MainPage/GetRecords",
                    data: JSON.stringify(id),
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (data)
                    {
                        ClearSelectRecords();
                        ClearFields();

                        var i = 1;

                        $.each(data, function ()
                        {
                            $("#recordSelect").append($("<option />").val(this.RecordId).text(i++ + " - " + "\[" + this.Action + "\]" + " - " + this.RecDate));
                        });
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
                ClearSelectRecords();
                ClearFields();
            }
        });
    }

    function CreateNewRecord()
    {
        if ($("#employeeSelect").val() != 0)
        {
            var id = { selectedEmployeeId: $("#employeeSelect").val() };

            $.ajax({
                type: "post",
                url: "/AddEmployeeRecord/Res",
                data: JSON.stringify(id),
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data)
                {
                    if (data.success)
                    {
                        window.location.href = "/AddEmployeeRecord/Index/";
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
            alert("You should select employee");
        }
    }

    function GetFieldsData()
    {
        $("#recordSelect").change(function ()
        {
            if ($("#recordSelect").val() != 0)
            {
                var id = { selectedRecordId: $("#recordSelect").val() };

                $.ajax({
                    type: "post",
                    url: "/MainPage/GetFieldsData",
                    data: JSON.stringify(id),
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (data)
                    {
                        var rec = $("#recordSelect option:selected").index();

                        $.each(data, function ()
                        {
                            $("#recordOutput").text(rec);
                            $("#dateOutput").text(this.RecDate);
                            $("#actionOutput").text(this.Action);
                            $("#descriptionOutput").text(this.Description);
                            $("#positionOutput").text(this.Position);
                            $("#documentOutput").text(this.ConfirmDocument);
                        });
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
                ClearFields();
            }
        });
    }

    function EditEmployee()
    {
        if ($("#employeeSelect").val() != 0)
        {
            var id = { selectedEmployeeId: $("#employeeSelect").val() };

            $.ajax({
                type: "post",
                url: "/EditEmployee/Res",
                data: JSON.stringify(id),
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data)
                {
                    if (data.success)
                    {
                        window.location.href = "/EditEmployee/Index/";
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
            alert("You should select employee to edit");
        }
    }

    function EditRecord()
    {
        if ($("#recordSelect").val() != 0)
        {
            var record = {
                employeeId: $("#employeeSelect").val(),
                recordId: $("#recordSelect").val()
            };

            $.ajax({
                type: "post",
                url: "/EditEmployeeRecord/Res",
                data: JSON.stringify(record),
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data)
                {
                    if (data.success)
                    {
                        window.location.href = "/EditEmployeeRecord/Index/";
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
            alert("You should select record to edit");
        }
    }

    $(document).ready(function ()
    {
        GetEmployees();
        GetRecords();
        GetFieldsData();

        $("#btnAddNewRec").click(function ()
        {
            CreateNewRecord();
        });

        $("#btnEditEmp").click(function ()
        {
            EditEmployee();
        });

        $("#btnEditRec").click(function ()
        {
            EditRecord();
        });
    });
}());