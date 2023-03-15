$("#publicNumber").click(function () {
    var data = $("#choose_number").val();

    var dataView = "";
    for (let i = 1; i <= data; i++) {
/*        alert(i);*/
        dataView += `
                      <label class="form-label">Nhập đáp án số `+ i + `</label>
                      <div class="input-group">
                                <input id="ques`+i+`" class="form-control" type="text" placeholder="Nhập câu số `+ i + `" required="required">
                      </div>
                          `
    }
    $("#renderNumber").html(dataView);
});

