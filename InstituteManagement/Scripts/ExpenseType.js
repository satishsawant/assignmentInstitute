
$(document).ready(function () {
    GetCourseType();
});
var BaseURL = "http://45.35.4.250/institutemgmt/api/";

//GEt All Expense Type
function GetExpenseType() {

    $.ajax({
        type: "GET",
        url: BaseURL + "Course/getallcoursetype",
        contentType: "application/json;",
        dataType: "json",
        success: function (data) {
            
            var arr = [];
            arr = data;
            $.each(arr, function (i, item) {
                
                var options = "<tr><td>" + item.ExpenseTypeId + "</td><td>" + item.ExpenseTypeName + "</td><td><p data-placement='top' data-toggle='tooltip' title='Edit'><button class='btn btn-primary btn-xs' onclick='setValueForEdit(" + '"' + item.ExpenseTypeId + '","' + item.ExpenseTypeName + '"' + ")' data-title='Edit' data-toggle='modal' data-target='#edit'><span class='glyphicon glyphicon-pencil'></span></button></p></td><td><p data-placement='top' data-toggle='tooltip' title='Delete'><button class='btn btn-danger btn-xs' data-title='Delete' data-toggle='modal' data-target='#delete'><span class='glyphicon glyphicon-trash'></span></button></p></td>";
                $('#expensetypebody').append(options);
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

//Add Expense Type
function ExpenseTypeCreate() {
    var expense = {
        "ExpenseTypeName": $("#expensetype").val()
    };
    $.ajax({
        type: "POST",
        url: BaseURL + "Course/CreateCourseType",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(expense),
        success: function (data) {
            alert(data);
        },

        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  
    });
}

//setValueForEdit
function setValueForEdit(id, name) {
    //debugger;
    $('#expensetypeid').val(id);
    $('#editexpensetypename').val(name);
}

//Edit Course Type
function CourseTypeEdit() {
    debugger;
    var course = {
        "CourseTypeName": $("#editexpensetypename").val(),
        "CourseTypeID": $('#expensetypeid').val()
    };
    $.ajax({
        type: "POST",
        url: BaseURL + "Course/UpdateCourseType",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(course),
        success: function (data) {
            alert(data);
        },

        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  
    });
}




//Delete ourse Type
function CourseTypeDelete() {
    $.ajax({
        type: "DELETE",
        url: BaseURL + "Course/DeleteCourseType",
        contentType: "json",
        dataType: "json",
        success: function (data) {
            alert("success.... " + data);
        },
        error: function () {
            alert('error');
        }
    });
}
