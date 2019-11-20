package commands

import (
	"fmt"
	"os"

	"github.com/akalinkin/devflow/cmd/devflow/features/contexts"
)

// ContextCmd used to work with contexts
func ContextCmd() {
	arg := ""
	if len(os.Args) >= 3 {
		arg = os.Args[2]
	}

	switch arg {
	case "l", "list":
		contextListCmd()
	case "a", "add":
		fmt.Println("!!!TODO:!!! context add command")
	case "r", "remove":
		fmt.Println("!!!TODO:!!! context remove command")
	case "c", "change":
		fmt.Println("!!!TODO:!!! context change command")
	case "s", "select":
		fmt.Println("!!!TODO:!!! context select command")
	case "i", "info", "":
		contextInfoCmd()
	default:
		// TODO: Add detailed help docs here
		fmt.Println("Wrong command. Allowed commands are: TODO: [list,add,remove]")
	}
}

var currentUID = "a1fc7355-30f3-47e3-97a3-86428c3527d3" // TODO: Get from current work session

func contextListCmd() {
	fmt.Println("Contexts list:")
	fmt.Println("==============")
	var ctxs = contexts.List()
	for _, v := range ctxs {
		if v.UID == currentUID {
			fmt.Println(v.UID, "\t", v.Name, "\t", v.Type.String(), "* ACTIVE")
		} else {
			fmt.Println(v.UID, "\t", v.Name, "\t", v.Type.String())
		}
	}
}

func contextInfoCmd() {
	fmt.Println("Current context:")
	fmt.Println("================")
	var c = contexts.Get(currentUID)
	fmt.Println(c.UID, "\t", c.Name, "\t", c.Type.String(), "* ACTIVE")
}
