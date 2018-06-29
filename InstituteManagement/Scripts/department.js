$(document).ready(function () {
    getDepartment();
});

function addDept() {
    debugger;
    var Department = { Department_Name: $('#deptname').val() };

    $.ajax({
        type: "POST",
        url: "http://localhost:50076/api/Department/CreateDepartment",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(Department),
        success: function (data) {
            alert(data);
        }, //End of AJAX Success function  

        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  

    });
}

function getDepartment() {
    debugger;
    $.ajax({
        type: "GET",
        url: "http://localhost:50076/api/Department/getdepartment/0",
        contentType: "application/json;",
        dataType: 'json',
        success: function (data) {
            // alert(data);
            //var res = JSON.parse(data);
            var teachers = data.success;
            var arr = [];
            arr = data.departments;
            $.each(arr, function (i, item) {
                var options = "<option class='dropdown-item' value=" + item.DepartmentID + ">" + item.Department_Name + "</option>";
                var options = "<tr><td>" + item.DepartmentID + "</td><td>" + item.Department_Name + "</td><td><p data-placement='top' data-toggle='tooltip' title='Edit'><button class='btn btn-primary btn-xs' data-title='Edit' data-toggle='modal' data-target='#edit'><span class='glyphicon glyphicon-pencil'></span></button></p></td><td><p data-placement='top' data-toggle='tooltip' title='Delete'><button class='btn btn-danger btn-xs' data-title='Delete' data-toggle='modal' data-target='#delete'><span class='glyphicon glyphicon-trash'></span></button></p></td>";
                $('#depttablebody').append(options);
            }); //End of foreach Loop   
        }, //End of AJAX Success function  

        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  

    });
}

function updateDept() {
    debugger;
    var Department = { Department_Name: $('#deptname').val() };

    $.ajax({
        type: "POST",
        url: "http://localhost:50076/api/Department/CreateDepartment",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(Department),
        success: function (data) {
            alert(data);
        }, //End of AJAX Success function  

        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  

    });
}