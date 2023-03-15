$(() => {
    LoadNotifications();
    var connection = new signalR.HubConnectionBuilder().withUrl("/signalRHub").build();
    connection.start();
    var parts = window.location.href.split('/');
    var id = parts.pop() || parts.pop();
    connection.on("LoadNotifications", function () {
        var parts = window.location.href.split('/');
        var id = parts.pop() || parts.pop();  // handle potential trailing slash
        LoadNotifications(id);
    })
    LoadNotifications(id);
    function LoadNotifications(id) {
        var tr = '';
        $.ajax({
            url: '/list/' + id,
            methods: 'GET',
            success: (result) => {
                $.each(result, (k, v) => {
                    tr += `<tr>
                                <td class="text-sm font-weight-normal">
                                    <a asp-route-id="@item.Id">${v.Id}</a>
                                </td>
                                <td class="text-sm font-weight-normal">
                                    ${v.IdUser}
                                </td>
                                <td class="text-sm font-weight-normal">
                                    ${v.IdForm.Name}
                                </td>
                                <td class="text-sm font-weight-normal">
                                    <a href="/tra-xuat-du-lieu/${v.IdForm.Id}/${v.IdUser}">View Grid</a>
                                    
                                </td>

                            </tr>`;

                })
                $("#idDataRepo").html(tr);
            },
            error: (error) => {
                console.log(error)
            }
        })
    }

})