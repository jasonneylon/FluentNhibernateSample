Fluent Nhibernate sample code

Advantages:
* Easier to write than XML, less verbose
* Discoverability
* Refactoring is easier
* Less context switching

Disadvantages
* Encourages De-encapsultion
* Certain rarely features not available so need to drop back to hbm .. (paramaterized user types?, collection flexibility?)

* Configuring the database connection
* Exporting the HBM
* Basic mappings
	- classmap
	- id (guids)
	- property
* Subclasses
* References/Has Many - ("Inverse on HasMany is an NHibernate term, and it means that the other end of the relationship is responsible for saving.")
* HasManyToMany
* Components
* Testing with persistent specification
* AutoMapping
* Conventions??