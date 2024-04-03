$(document).ready(function () {
    $("#openPopupLink").click(function (e) {
        e.preventDefault(); // Prevent default link behavior
        $("#feedbackText").val(""); // Clear textarea value
        // Open the dialog with custom width and height
        $("#dialog").dialog({
            width: 600, // Set width to 600 pixels
            height: 400, // Set height to 400 pixels
            resizable: false,// Make the dialog not resizable
            position: { my: "center", at: "center", of: window }
        });
    });

    $("#submitButton").click(function () {
        var feedback = $("#feedbackText").val();

        // Send the feedback to the server or perform any desired action
        alert("Feedback submitted: " + feedback);
        $("#feedbackText").val(""); // Clear textarea value
        $("#dialog").dialog("close");
    });

    $("#cancelButton").click(function () {
        $("#feedbackText").val(""); // Clear textarea value
        $("#dialog").dialog("close");
    });
    $("#dialog").dialog({
        autoOpen: false
    });


});


function SubmitButton_Click() {
    // Retrieve the feedback text from the textarea
    var feedbackText = document.getElementById("feedbackText").value;

    // Your email sending logic here
    // You can use AJAX to send the feedback to the server-side code
    // Or you can perform any other action as needed
}

