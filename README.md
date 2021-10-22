![alt text](https://github.com/211004-Reston-NET/Michael_Mason_P0/blob/edge/db_diagram.png?raw=true)

### DAL
- db => entity
- entity => repository

### BAL
- repository => logic

### Model
- logic => validation

### UI
- validation => interaction

<=>

### UI
- interaction => validation

### Model
- validation => logic

### BAL
- logic => repository

### DAL
- repository => entity
- entity => db
