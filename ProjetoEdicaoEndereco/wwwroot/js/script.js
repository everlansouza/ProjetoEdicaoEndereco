$(document).ready(function () {
    $('#documento').inputmask('999.999.999-99');

    $('#Cep').inputmask('99999-999');

    $(document).on('change', '#Cep', function () {
        let cep = $(this).val().replace(" ", "");

        buscaCep(cep, 'Logradouro', 'Bairro', 'Numero', 'CidadesId', 'EstadosId');
    });

    $('#EstadoId').change(function () {
        var estadoId = $(this).val();
        if (estadoId) {
            buscarCidades(estadoId);
        } else {
            $('#cidadeSelect').empty();
        }
    });

    function buscarCidades(estadoId) {
        fetch(`/api/cidades/${estadoId}`)
            .then(response => response.json())
            .then(cidades => {
                $('#CidadeId').empty();
                $.each(cidades, function (i, cidade) {
                    $('#CidadeId').append($('<option>', {
                        value: cidade.id,
                        text: cidade.nome
                    }));
                });
            })
            .catch(error => {
                console.error("Erro ao buscar cidades:", error);
            });
    }

    function buscaCep(cep) {
        let sonumeros = cep.replace(/\D/g, "");

        if (parseInt(sonumeros).toString().length !== 8)
            return false;

        $.get(`https://viacep.com.br/ws/${sonumeros}/json/`, function (response) {
            console.log(response)
            if (response.erro) {
                return false;
            } else {
                //buscaEstadosCidades(response.uf);
                //É necessario uma periodo maior para finalizar o projeto

                $('#Logradouro').val(response.logradouro);
                $('#Bairro').val(response.bairro);
                $('#Numero').focus();
            }

        }, 'json');
    }
});


