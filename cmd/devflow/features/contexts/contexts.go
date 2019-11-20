package contexts

// Context using in working session
type Context struct {
	UID   string
	Name  string
	Type  Type
	Token string
	URL   string
}

// Type of context
type Type int

const (
	// Undefined or wrong context type
	Undefined Type = 0
	// Local context - handles all data localy
	Local Type = 1
	// GitLab context - use GitLab API as tasks source
	GitLab Type = 2
)

func (d Type) String() string {
	return [...]string{"Undefined", "Local", "GitLab"}[d]
}

// Features

var fakeContexts = []Context{
	{
		UID:  "a1fc7355-30f3-47e3-97a3-86428c3527d3",
		Name: "Work project 1",
		Type: Local,
	},
	{
		UID:  "eb17e94d-8c4b-42ff-9008-e9850c20788d",
		Name: "My Pet project",
		Type: GitLab,
	},
}

// List all existing contexts
func List() []Context {
	// TODO: Get context from Reader (passed as param and implementing interface ContextReader)
	var l = fakeContexts

	return l
}

// Get context by provided UID
func Get(UID string) *Context {
	// TODO: Find context by UID and return it
	return &fakeContexts[0]
}

// func Get(name string) {

// }

// func Add(ctx Context) {

// }

// func Change(ctx Context) {

// }

// func Remove(ctx Context) {

// }
