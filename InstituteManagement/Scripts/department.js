$(document).ready(function () {
    getDepartment();
});


var BaseUrl = "http://45.35.4.250/institutemgmt/api/";
function addDept() {
    debugger;
   
    if ($('#createform').validator('check') < 1) {

    }
    else {
        var dept = $('#deptname').val();
        var Department = { Department_Name: dept };
        startLoading();
        $.ajax({
            type: "post",
            url: baseurl + "department/createdepartment",
            contenttype: "application/json",
            datatype: "json",
            data: JSON.stringify(Department),
            success: function (data) {
                alert(data);
            }, //end of ajax success function  

            failure: function (data) {
                alert(data.responsetext);
            }, //end of ajax failure function  
            error: function (data) {
                alert(data.responsetext);
            } //end of ajax error function  
        });
    }
        
        $('#create').modal('toggle');    
}
function getDepartment() {
    $.ajax({
        type: "GET",
        url: BaseUrl+"Department/getdepartment/0",
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
                var options = "<tr><td>" + item.DepartmentID + "</td>"
                + "<td>" + item.Department_Name + "</td><td><p data-placement='top' data-toggle='tooltip' title='Edit'><button class='btn btn-primary btn-xs' data-title='Edit' data-toggle='modal' onclick='setValueforEdit(" + '"' + item.DepartmentID + '","' + item.Department_Name +'"' + ")' data-target='#edit'><span class='glyphicon glyphicon-pencil'></span></button></p></td><td><p data-placement='top' data-toggle='tooltip' title='Delete'><button class='btn btn-danger btn-xs' data-title='Delete' data-toggle='modal' data-target='#delete'><span class='glyphicon glyphicon-trash'></span></button></p></td>";
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
function setValueforEdit(deptId, deptName) {
    $("#deptnameedit").val(deptName);
    $("#editDeptId").val(deptId);
}
function updateDept() {
    debugger;
    var Department = {
        Department_Name: $('#deptnameedit').val(),
        DepartmentID: $('#editDeptId').val()
    };
    $.ajax({
        type: "POST",
        url: BaseUrl+"Department/UpdateDepartment",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(Department),
        success: function (data) {
            if (data = 'success')
            { alert('Updated Successfully') }
        }, //End of AJAX Success function  

        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  

    });
    $('#edit').modal('toggle');
}
