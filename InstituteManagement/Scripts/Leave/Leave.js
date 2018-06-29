//GET Leave By Id
function GetLeaveById() {
    $.ajax({
        type: "GET",
        url: "/api/Leave/Get",
        contentType: "json",
        dataType: "json",
        success: function (data) {
            //stringify
            var jsonData = JSON.stringify(data);
            //Parse JSON
            var objData = $.parseJSON(jsonData);
            var objData = $.parseJSON(jsonData);
            var id = objData.LeaveTypeID;
            var fromdate = objData.DateFrom;
            var todate = objData.DateTo;
            var reason = objData.Reason;
            var approve = objData.IsApproved;

            AppendTo('#leavetable');
        },
        error: function () {
            alert("Error");
        }
    });
}
//GetAll Leave
function GetAllLeave() {
    $.ajax({
        type: "GET",
        url: "/api/Leave/Get",
        contentType: "json",
        dataType: "json",
        success: function (data) {

            $.each(data, function (key, value) {
                //stringify
                var jsonData = JSON.stringify(value);
                //Parse JSON
                var objData = $.parseJSON(jsonData);
                var id = objData.LeaveTypeID;
                var fromdate = objData.DateFrom;
                var todate = objData.DateTo;
                var reason = objData.Reason;
                var approve = objData.IsApproved;

                AppendTo('#leavetable');

            });
        },
        error: function () {
            alert("Error");
        }
    });
}
//Add Leave
function CreateLeave() {
    var cors = {
        "LeaveTypeID": $("#levetype").val(),
        "DateFrom": $("stratdate").val(),
        "DateTo": $("#enddate").val(),
        "Reason": $("#reason").val(),
        "IsApproved": $("#isapprove").val()
    };
    $.ajax({
        type: 'POST',
        url: '/api/Leave/Create',
        data: JSON.stringify(cors),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        success: function (data) {
            alert("Create Leave Successfully");
        },
        error: function () {
            alert('error');

        }
    })
}

