
    function EditTodo(elem) {
        var isDone = $(elem).is(':checked');

        var id = $(elem).attr('id')
        var url = "/Home/EditTodo"
        $.ajax({
            type: 'POST',
            url: url,
            data: { id:id },
            success: function(res) {
                console.log(res);
            },
            dataType: 'json'
        });

        if(isDone) 
        {
            $(elem).parent().parent().removeClass('none')
            $(elem).parent().parent().addClass('completed')
        }
        else
        {
            $(elem).parent().parent().removeClass('completed')
            $(elem).parent().parent().addClass('none')
        }
    }


    
    function EditTodos(elem) {
        var isDone = $(elem).is(':checked');

        var id = $(elem).attr('id')
        var url = "";
        $.ajax({
            type: 'POST',
            url: url,
            data: { id:id },
            success: function(res) {
                console.log(res);
            },
            dataType: 'json'
        });

    }

