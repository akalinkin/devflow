package main

import "github.com/ilyakaznacheev/cleanenv"

// Config - struct used to be filled by values from .env File or
// 	        environment variables
type Config struct {
	Token        string `env:"GLCLI_GITLAB_PERSONAL_ACCESS_TOKEN"`
	GitLabServer string `env:"GLCLI_GITLAB_FQDN"`
}

// Init - initializes and returns config
func Init() Config {
	var c Config

	err := cleanenv.ReadEnv(&c)
	if err != nil {

	}

	return c
}
