###DAL
- db => entity
- entity => repository

###BAL
- repository => logic

###Model
- logic => validation

###UI
- validation => interaction

<=>

###UI
- interaction => validation

###Model
- validation => logic

###BAL
- logic => repository

###DAL
- repository => entity
- entity => db