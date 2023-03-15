var obj = {};
var i = parseInt(document.getElementById("onClickButton").getAttribute("val-data"));
for (let x = 1; x <= i; x++) {
    $(`#Question` + x).click(function () {
        //Điều kiện nếu như chưa điền đầy đủ thì ở lại
        if ($("#completeChoose").attr("data-val") == null) {
            obj = {};
            $("#textNumber").html("Question " + x);
            $("#completeChoose").html("Bạn đang chọn câu hỏi số : " + x);
            $("#completeChoose").attr("data-val", x);
            $("#nameQuestion").removeAttr("disabled");
            $("#descriptionQuestion").removeAttr("disabled");
        } else {
            if ($("#nameQuestion").val() == "" || $("#descriptionQuestion").val() == "") {
                alert("Lỗi rồi ba")
            } else {
                var dataQues = "";
                for (let y = 1; y <= $("#choose_number").val(); y++) {
                    dataQues += $(`#ques` + y).val();
                    if (y < $("#choose_number").val()) {
                        dataQues += "%%";
                    }
                }
                var draw = $("#draw").val();
                if (draw == "choose") {
                    obj = {
                        number: $("#completeChoose").attr("data-val"),
                        nameQuestion: $("#nameQuestion").val(),
                        descriptionQuestion: $("#descriptionQuestion").val(),
                        type: 1,
                        question: dataQues
                    }
                }
                if (draw == "numberchoose") {
                    obj = {
                        number: $("#completeChoose").attr("data-val"),
                        nameQuestion: $("#nameQuestion").val(),
                        descriptionQuestion: $("#descriptionQuestion").val(),
                        type: 2,
                        question: "%%"
                    }
                }
                if (draw == "survey") {
                    obj = {
                        number: $("#completeChoose").attr("data-val"),
                        nameQuestion: $("#nameQuestion").val(),
                        descriptionQuestion: $("#descriptionQuestion").val(),
                        type: 3,
                        question: "%%"
                    }
                }
                
                fullData.push(obj);
                $("#textNumber").html("Question " + x);
                $("#completeChoose").html("Bạn đang chọn câu hỏi số : " + x);
                $("#completeChoose").attr("data-val", x);
                $("#nameQuestion").removeAttr("disabled");
                $("#descriptionQuestion").removeAttr("disabled");
                obj = {};
                $("#nameQuestion").val("")
                $("#descriptionQuestion").val("")
                $("#renderNumber").html("")
                $("#reviewView").html("")
            }
        }
    })
}


