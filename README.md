Este projeto implementa uma API RESTful para gerenciamento de posts de blog e seus comentários associados.
O código está pronto para rodar no Visual Studio, utilizando a solução do projeto.
Ao iniciar a aplicação, o Swagger será aberto automaticamente para facilitar o teste dos endpoints.

Abra a solução no Visual Studio (.sln).

Verifique a string de conexão no arquivo appsettings.json.
O projeto está configurado para usar um banco de dados fictício, mas você pode alterá-lo conforme necessário.

Execute a aplicação (Ctrl + F5).
O Swagger será carregado automaticamente com os endpoints disponíveis:

  GET /api/posts

  GET /api/posts/{id}

  POST /api/posts

  POST /api/posts/{id}/comments

Com mais tempo, seria possível implementar:

Validações adicionais (ex.: tamanho máximo de campos e obrigatoriedade), Autenticação e autorização via OAuth 2.0, Paginação e filtros nos endpoints de listagem.
