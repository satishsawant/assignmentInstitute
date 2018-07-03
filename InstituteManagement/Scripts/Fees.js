$(document).ready(function () {
    GetAllCourse()
    GetAllFeeTranscation()
    
});

var BaseURL = "http://45.35.4.250/institutemgmt/api/";

function AddNewFeeTranscation() {

    var FeeTranscationData = {
        StudentID: $('#studid').val(),
        CourseID: $('#course').val(),
        Date: $('#datetimepicker').val(),
        FeesPaid: $('#amt').val(),
       };

    $.ajax({
        type: "POST",
        url: BaseURL+"",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(FeeTranscationData),
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

// GET ALL
function GetAllFeeTranscation() {
    debugger;
    $.ajax({
        type: "GET",
        url: BaseURL+"",
        contentType: "application/json;",
        dataType: "json",
        success: function (data) {
            var success = data.Success;
            var arr = [];
            arr = data.Transcation;
            window.tran = arr;
            $.each(arr, function (key, objData) {
                var id = objData.FeesTranscationID;
                var studid = objData.StudentID;
                var courseid = objData.CourseID;
                var date = objData.Date;
                var feespaid = objData.FeesPaid;
                $('<tr id="Tr_stud_' + id + '"><td>' + id + '</td><td>' + studid +
                                    '</td><td>' + courseid + '</td><td>' + date + '</td><td>' + feespaid + "</td><td><p data-placement='top' data-toggle='tooltip' title='Edit'><button class='btn btn-primary btn-xs' data-title='Edit' onclick='EditTranscation(" + key + ")'><span class='glyphicon glyphicon-pencil'></span></button></p></td><td><p data-placement='top' data-toggle='tooltip' title='Delete'><button class='btn btn-danger btn-xs' data-title='Delete' data-toggle='modal' data-target='#delete'><span class='glyphicon glyphicon-trash'></span></button></p></td>")
                                    .appendTo('#mytable');

            });
        },
        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error fun
    });
}

function EditTranscation(key) {
    debugger;
    if (window.stud) {
        var stud = window.tran[key];
        $('#StudentEditModel').modal('show');
        $('#studid').val(stud.StudentID);
        $('#course').val(stud.CourseID);
        $('#datetimepicker').val(stud.Date);
        $('#amt').val(stud.FeesPaid);
        }
}
function setValueforEdit() {
    debugger;
    alert('alert1');
    if (window.selectedstud) {
        alert(window.selectedstud.First_Name);
    }
    var newobj = window.selectedstud;

    $('#editfirst').val(newobj.First_Name);
}

function GetAllCourse() {
    debugger;
    $.ajax({
        type: "GET",
        url: BaseURL + "Course/GetAll",
        contentType: "json",
        dataType: "json",
        success: function (data) {
            //var course = data.success;
            var arr = [];
            arr = data;
            var courseTypeName;
            $.each(arr, function (i, item) {
                courseTypeName = GetCourseTypeById(item.CourseTypeId);
                var options = "<tr><td>" + courseTypeName + "</td><td>" + item.CourseName + "</td><td>" + item.Duration + "</td> <td>" + item.Fees + "</td> <td><p data-placement='top' data-toggle='tooltip' title='Edit'><button class='btn btn-primary btn-xs' onclick='setValueForEdit(" + '"' + item.CourseID + '","' + item.CourseTypeName + '","' + item.CourseName + '","' + item.Duration + '","' + item.Fees + '"' + ")' data-title='Edit' data-toggle='modal' data-target='#edit'><span class='glyphicon glyphicon-pencil'></span></button></p></td><td><p data-placement='top' data-toggle='tooltip' title='Delete'><button class='btn btn-danger btn-xs' data-title='Delete' data-toggle='modal' data-target='#delete'><span class='glyphicon glyphicon-trash'></span></button></p></td>";
                $('#course').append(options);
            }); //End of foreach Loop 
        },
        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  
    });
}

//DELETE
function DeleteFeeTranscation() {
    $.ajax({
        type: "DELETE",
        url: "http://45.35.4.250/institutemgmt/api/student",
        contentType: "json",
        dataType: "json",
        success: function (data) {
            alert("success.... " + data);
        },
        error: function (xhr) {
            alert(xhr.responseText);
        }
    });
}

function UpdateFeeTranscation() {
    debugger;
    var id = $('#studid').val();
    var FeeTranscationData = {
        StudentID: $('#first').val(),
        CourseID: $('#Middle').val(),
        Date: $('#Last').val(),
        FeesPaid: $('#address1').val()
        };

    $.ajax({
        type: "POST",
        url: "http://45.35.4.250/institutemgmt/api/" + id,
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(studentData),
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