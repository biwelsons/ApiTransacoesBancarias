<!DOCTYPE html>
<html lang="en">

<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
</head>

<body>

  <header>
    <h1>API de Transações Bancárias</h1>
    <img src="https://upload.wikimedia.org/wikipedia/commons/0/0e/Microsoft_.NET_logo.png"
         alt=".NET Logo"
         width="35">
  </header>

  <section>
    <h2>Readme</h2>
    <p>This project is an API built using .NET, EntityFramework, PostgresSQL as the database, and authentication control.</p>
    <p>The API was developed for a IT entity at my college, of which I am a part..</p>
  </section>

  <section>
    <body>
    <h2>API Endpoints:</h2>
    <h3>1. Authentication</h3>
    <p>
        <strong>Description:</strong> Endpoint to authenticate users and generate JWT tokens for accessing protected API
        resources.<br>
        <strong>Method:</strong> POST<br>
        <strong>Route:</strong> /v1/login<br>
        <strong>Request Format:</strong>
        <pre>{
    "Username": "string",
    "Password": "string"
}</pre>
        <strong>Possible Responses:</strong>
        <ul>
            <li>200 OK: Returns authenticated user data and a JWT token.</li>
            <li>404 Not Found: Invalid username or password.</li>
        </ul>
    </p>
    <h3>2. List All Transactions</h3>
    <p>
        <strong>Description:</strong> Endpoint to list all existing transactions.<br>
        <strong>Method:</strong> GET<br>
        <strong>Route:</strong> /api/Transacao<br>
        <strong>Request Format:</strong> Not applicable (does not require a body)<br>
        <strong>Possible Responses:</strong>
        <ul>
            <li>200 OK: Returns a list of all transactions.</li>
        </ul>
    </p>
    <h3>3. Fetch Transaction by ID</h3>
    <p>
        <strong>Description:</strong> Endpoint to fetch a specific transaction by ID.<br>
        <strong>Method:</strong> GET<br>
        <strong>Route:</strong> /api/Transacao/{id}<br>
        <strong>Request Format:</strong> Not applicable (does not require a body)<br>
        <strong>Possible Responses:</strong>
        <ul>
            <li>200 OK: Returns details of the requested transaction.</li>
            <li>404 Not Found: Transaction not found.</li>
        </ul>
    </p>
    <h3>4. Create New Transaction</h3>
    <p>
        <strong>Description:</strong> Endpoint to create a new transaction.<br>
        <strong>Method:</strong> POST<br>
        <strong>Route:</strong> /api/Transacao<br>
        <strong>Request Format:</strong>
        <pre>{
    "DataHora": "datetime",
    "ModoTransacao": "string",
    "Categoria": "string",
    "NotaObservacao": "string",
    "Valor": "decimal",
    "TipoTransacao": "string"
}</pre>
        <strong>Possible Responses:</strong>
        <ul>
            <li>201 Created: Returns details of the created transaction.</li>
        </ul>
    </p>
    <h3>5. Update Transaction</h3>
    <p>
        <strong>Description:</strong> Endpoint to update an existing transaction.<br>
        <strong>Method:</strong> PUT<br>
        <strong>Route:</strong> /api/Transacao/{id}<br>
        <strong>Request Format:</strong>
        <pre>{
    "DataHora": "datetime",
    "ModoTransacao": "string",
    "Categoria": "string",
    "NotaObservacao": "string",
    "Valor": "decimal",
    "TipoTransacao": "string"
}</pre>
        <strong>Possible Responses:</strong>
        <ul>
            <li>200 OK: Transaction updated successfully.</li>
            <li>400 Bad Request: Invalid request.</li>
            <li>404 Not Found: Transaction not found.</li>
        </ul>
    </p>
    <h3>6. Delete Transaction</h3>
    <p>
        <strong>Description:</strong> Endpoint to delete an existing transaction by ID.<br>
        <strong>Method:</strong> DELETE<br>
        <strong>Route:</strong> /api/Transacao/{id}<br>
        <strong>Request Format:</strong> Not applicable (does not require a body)<br>
        <strong>Possible Responses:</strong>
        <ul>
            <li>204 No Content: Transaction deleted successfully.</li>
            <li>404 Not Found: Transaction not found.</li>
        </ul>
    </p>
    <h3>7. Reverse Transaction by ID (Update Version)</h3>
    <p>
        <strong>Description:</strong> Endpoint to reverse a specific transaction by ID (update version).<br>
        <strong>Method:</strong> PUT<br>
        <strong>Route:</strong> /api/Transacao/Estorno/{id}<br>
        <strong>Request Format:</strong> Not applicable (does not require a body)<br>
        <strong>Possible Responses:</strong>
        <ul>
            <li>200 OK: Transaction reversed successfully.</li>
            <li>404 Not Found: Transaction not found.</li>
        </ul>
    </p>
    <h3>8. Reverse Transaction by ID</h3>
    <p>
        <strong>Description:</strong> Endpoint to reverse a specific transaction by ID.<br>
        <strong>Method:</strong> DELETE<br>
        <strong>Route:</strong> /api/Transacao/Estorno/{id}<br>
        <strong>Request Format:</strong> Not applicable (does not require a body)<br>
        <strong>Possible Responses:</strong>
        <ul>
            <li>200 OK: Transaction reversed successfully.</li>
            <li>404 Not Found: Transaction not found.</li>
        </ul>
    </p>
    <h3>9. Filter Transactions</h3>
    <p>
        <strong>Description:</strong> Endpoint to filter transactions based on different criteria.<br>
        <strong>Method:</strong> GET<br>
        <strong>Route:</strong> /api/Transacao/FiltrarTransacoes<br>
        <strong>Request Format:</strong>
        <pre>{
    "Data": "string",
    "ModoTransacao": "string",
    "Categoria": "string",
    "NotaObservacao": "string",
    "Valor": "decimal",
    "TipoValor": "string",
    "TipoTransacao": "string"
}</pre>
        <strong>Possible Responses:</strong>
        <ul>
            <li>200 OK: Returns the filtered list of transactions.</li>
        </ul>
    </p>

  </section>

  <section>
    <h2>Database</h2>
    <p>The project utilizes PostgresSQL as the database.<p/>
  </section>

</body>

</html>
