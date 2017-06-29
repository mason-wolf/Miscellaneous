      function dropdown(value) {
        var dropdown = document.getElementsByClassName('btn btn-secondary dropdown-toggle');
        var node = dropdown[0].innerHTML = value + ' <span class="caret"></span>';
        document.getElementById('City').value = value;
      }
